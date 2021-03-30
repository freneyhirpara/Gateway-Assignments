const { Pool, Client } = require('pg');


exports.handler =  function(event, context, callback) {
  try{
const con = new Pool({
  user: 'postgres',
  host: 'customer.cwhwdswgubl6.ap-south-1.rds.amazonaws.com',
  database: 'postgres',
  password: 'Freney',
  port: 5432,
})
const id = event.pathParameters.id;

const query = "select * from customers where id =" + id;

  con.query(query,(err,res)=>{
    if(err){
      con.end();
     throw err;
    }
    else{
    
      callback(null,{
        "statusCode": 200,
        headers: {
          "Access-Control-Allow-Origin": "*"
        },
        "body": JSON.stringify(res.rows),
        "isBase64Encoded": false
      })
      con.end();
    }
  })
}
catch(err){
  callback(err,{
        "statusCode": 400,
        headers: {
          "Access-Control-Allow-Origin": "*"
        },
        "body": JSON.stringify(err),
        "isBase64Encoded": false
      })
}
}  