var dbConnection = require('../../../utilities/postgresql-connection.js');
//var generateToken = require('../../../utilities/generate-token.js');
var validate = require('validator');
var HttpStatusCode = require("http-status-codes");

exports.createCar = function (req, res) {
    
    var entityData = {
        CarName  : req.body.Name,
        MakeName : req.body.MakeName,
        ModelName : req.body.ModelName,
    };
    
    function validateFields(req, res) {
        return new Promise(function (resolve, reject) {
            var isCarNameEmpty = validate.isEmpty(req.body.Name);
            if (isCarNameEmpty) {
                return reject({
                    status: HttpStatusCode.StatusCodes.BAD_REQUEST,
                    data: req.i18n.__('CarNameRequired')
                });
            }
            

            var isMakeNameEmpty = validate.isEmpty(req.body.MakeName);
            if (isMakeNameEmpty) {
                return reject({
                    status: HttpStatusCode.StatusCodes.BAD_REQUEST,
                    data: req.i18n.__('MakeNameRequired')
                });
            }

            var isModelNameEmpty = validate.isEmpty(req.body.ModelName);
            if (isModelNameEmpty) {
                return reject({
                    status: HttpStatusCode.StatusCodes.BAD_REQUEST,
                    data: req.i18n.__('ModelNameRequired')
                });
            }
            
            return resolve({
                status: HttpStatusCode.StatusCodes.OK,
                data: entityData
            });
        });
    }

    function createCar(req, entityData) {
        return new Promise(function (resolve, reject) {
            var sqlQuery = "SELECT Name from car WHERE Name='" + entityData.CarName + "'";
            dbConnection.getResult(sqlQuery).then(function (response) {
                if (response.data.length == 0) {
                    var makeCheckQuery = "SELECT name from make where name = '" + entityData.MakeName + "'";
                    dbConnection.getResult(makeCheckQuery).then(function (response) {
                        if (response.data.length == 0) {
                            var makeAddQuery = "INSERT INTO make (name) VALUES  ('" + entityData.MakeName + "')";
                            dbConnection.getResult(makeAddQuery).then(function (response) {})
                        }
                    })
                    
                    var modelCheckQuery = "SELECT name from model where name = '" + entityData.ModelName + "'";
                    dbConnection.getResult(modelCheckQuery).then(function (response) {
                        if (response.data.length == 0) {
                            var modelAddQuery = "INSERT INTO model (name) VALUES  ('" + entityData.ModelName + "')";
                            dbConnection.getResult(modelAddQuery).then(function (response) {})
                        }
                    })

                    var makeIdQuery = "SELECT id from make WHERE name =  '" + entityData.MakeName + "'";
                    dbConnection.getResult(makeIdQuery).then(function (response) {
                        if (response.data.length != 0) {
                            console.log(response.data[0].id);
                            const makeid = response.data[0].id;
                            var modelIdQuery = "SELECT id from model WHERE name ='" + entityData.ModelName + "'";
                            dbConnection.getResult(modelIdQuery).then(function (response) {
                                if (response.data.length != 0) {
                                    const modelid = response.data[0].id;
                                    var carAddQuery = "INSERT INTO car (Name, makeid,modelid) VALUES ( '" + entityData.CarName + "','" + makeid + "','" + modelid + "')";
                                    dbConnection.getResult(carAddQuery).then(function (response) {
                                        return resolve({
                                            status: HttpStatusCode.StatusCodes.OK,
                                            message: 'Car added successfully!!!'
                                        });  
                                    })


                                }
                            })
                        }
                    })




                                      
                } else {
                    return resolve({
                        status: HttpStatusCode.StatusCodes.OK,
                        message: 'Car with same Name already exists!! '
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
        createCar(req, response.data).then(function (response) {
            res.status(response.status).json({
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