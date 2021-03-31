const { Pool, Client } = require('pg');
var bcrypt = require('bcryptjs');
const AWS = require('aws-sdk');
const parser = require('lambda-multipart-parser');
const sharp = require('sharp');

var s3 = new AWS.S3(
    {
    });

exports.handler = async (event, context, callback) => {
     
        const con = new Pool({
          user: 'postgres',
          host: 'customer.cwhwdswgubl6.ap-south-1.rds.amazonaws.com',
          database: 'postgres',
          password: 'Freney',
          port: 5432,
        })

        const result = await parser.parse(event);
        const image = result.files[0];

        let decodedImage = await sharp(Buffer.from(image.content, 'base64')).png().toBuffer();
        let decodedThumbnail = await sharp(decodedImage).resize(200).png().toBuffer();
        const date = new Date();
        const newDate = date.toISOString().replace("T", "_").replace(/:/g, "-").replace(".","-");

    
        var filePath =  "images/" + newDate +  ".png";
        var fileName =  "https://gtl-upload-image.s3.ap-south-1.amazonaws.com/"+"images/" + newDate +  ".png";
        var params = {
           "Body": decodedImage,
           "Bucket": "gtl-upload-image",
           "Key": filePath,
           "ContentType": 'image/png', 
           "ContentEncoding": 'base64',
           'ACL':'public-read'
       
        };
       
        var thumbnailPath =  "thumbnail/" + newDate +  ".png";
        var thumbnailName =  "https://gtl-upload-image.s3.ap-south-1.amazonaws.com/"+"thumbnail/" + newDate +  ".png";
        var thumbnailParams = {
           "Body": decodedImage,
           "Bucket": "gtl-upload-image",
           "Key": thumbnailPath,
           "ContentType": 'image/png', 
           "ContentEncoding": 'base64',
           'ACL':'public-read'
       
        };
        const name = result.name;
        const password = result.password;
        const username= result.email;
        const contactnumber = result.contactnumber;
        const status = result.status;
        var salt = bcrypt.genSaltSync(10);
        var hash = bcrypt.hashSync(password, salt);
        
        const checkEmail = `Select * from customers where email = '${username}'`;
        await con.query(checkEmail)
            .then(async data => {
                if(data.rowCount==0){
                    
                     await s3.putObject(params).promise();
                     await s3.putObject(thumbnailParams).promise();
                    const query = `INSERT INTO customers (name,email,password,contactnumber,image,thumbnail,status) VALUES ('${name}','${username}','${hash}','${contactnumber}','${fileName}','${thumbnailName}',true) RETURNING id,name,image`;
                    await con.query(query)
                    .then(dataa => {
                        callback(null,{
                            statusCode: 200,
                            headers: {
                                "Access-Control-Allow-Origin": "*"
                            },
                            body: JSON.stringify(dataa.rows[0]),
                            isBase64Encoded: false
                        });
                        con.end();
                    })
                    .catch(err => {
                        callback({
                            statusCode: 400,
                            headers: {
                                "Access-Control-Allow-Origin": "*"
                            },
                            body: JSON.stringify(err),
                            isBase64Encoded: false
                        },null);
                    });
                }
                else{
                    con.end();
                    callback(null,{
                        statusCode: 200,
                        headers: {
                            "Access-Control-Allow-Origin": "*"
                        },
                        body: JSON.stringify("Email already exists!"),
                        isBase64Encoded: false
                    });
                }
            })
            .catch(err => {
                callback({
                    statusCode: 400,
                    headers: {
                        "Access-Control-Allow-Origin": "*"
                    },
                    body: JSON.stringify(err),
                    isBase64Encoded: false
                },null);
            });
};
