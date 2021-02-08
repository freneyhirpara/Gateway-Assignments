var dbConnection = require('../../../utilities/postgresql-connection.js');
var generateToken = require('../../../utilities/generate-token.js');
var validate = require('validator');
var HttpStatusCode = require("http-status-codes");
var settings = require('../../../config.js');
//const { settings } = require('../../../app.js');

exports.uploadImage = function (req, res) {
    
    var entityData = {
        id: req.params.id,
        filename: req.file.filename,
        currentdate: new Date()
    };
    
    function validateFields(req, res) {
        return new Promise(function (resolve, reject) {
            var isFilenameEmpty = validate.isEmpty(req.file.filename);
            if (isFilenameEmpty) {
                return reject({
                    status: HttpStatusCode.StatusCodes.BAD_REQUEST,
                    data: req.i18n.__('FileRequired')
                });
            }
            /*
            var isInvalidEmail = validate({
                Email: req.body.Email
            }, {
                Email: {
                    email: true
                }
            });
            if (isInvalidEmail) {
                return reject({
                    status: HttpStatusCode.StatusCodes.BAD_REQUEST,
                    data: req.i18n.__('InvalidEmail')
                });
            }
            */

            
            return resolve({
                status: HttpStatusCode.StatusCodes.OK,
                data: entityData
            });
        });
    }

    function uploadImage(req, entityData) {
        return new Promise(function (resolve, reject) {
            const sqlQuery = "SELECT  id FROM car WHERE id= " + entityData.id;
            dbConnection.getResult(sqlQuery).then(function (response) {
                if (response.data.length != 0) {
                    
                    const sqlQuery2 = "INSERT INTO carimage (carid,imagename) VALUES (" + entityData.id + ",'" +entityData.filename+ "')";
                     dbConnection.getResult(sqlQuery2).then(function (response) {
                    
                        return resolve({
                            status: HttpStatusCode.StatusCodes.OK,
                            message: 'fileUrl: "http://localhost:'+ settings.server.PORT+ '/images/' + req.file.filename +'"'
                        });
                    
                })


                                        
                } else {
                    return resolve({
                        status: HttpStatusCode.StatusCodes.OK,
                        message: 'Car does not exist'
                    });
                }                
            })
            .catch(function (error) {
                res.status(HttpStatusCode.StatusCodes.BAD_REQUEST).json({
                    data: error.data
                });
            });
        });
    }

    validateFields(req, res).then(function (response) {
        uploadImage(req, response.data).then(function (response) {
            res.status(response.status).json({
                data: response.token,
                message: response.message
            });
        })
        .catch(function (error) {
            res.status(HttpStatusCode.StatusCodes.BAD_REQUEST).json({
                data: error.data
            });
        });
    })
    .catch(function (error) {
        res.status(HttpStatusCode.StatusCodes.BAD_REQUEST).json({
            data: error.data
        });
    });
    
}