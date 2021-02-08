var StatusCode = require('http-status-codes');
var dbConnection = require('../../../utilities/postgresql-connection.js');
var settings = require('../../../config.js');
var validate = require('validator');
var HttpStatusCode = require("http-status-codes");

exports.getCarById = function (req, res) {
    var entityData = {
        Id: req.params.id
    };

    function validateFields(req, res) {
        return new Promise(function (resolve, reject) {
            var isUserIdEmpty = validate.isEmpty(entityData.Id);
            if (isUserIdEmpty) {
                return resolve({
                    status: HttpStatusCode.StatusCodes.BAD_REQUEST,
                    result: req.i18n.__('UserIdRequired')
                });
                //return res.status(400).send({ result: req.i18n.__('UserIdRequired') });
            }
            
            return resolve({
                status: HttpStatusCode.StatusCodes.OK,
                data: entityData
            });
        });
    }

    function getCarById(req, entityData) {
        return new Promise(function (resolve, reject) {
            const sqlQuery = 'SELECT car.id, car.Name AS Car_Name, make.Name AS Make_Name, model.Name AS Model_Name, array_agg(carimage.imagename) as image FROM car LEFT JOIN make ON (car.makeid=make.id) LEFT JOIN model ON (car.modelid=model.id) LEFT JOIN carimage ON (car.id=carimage.carid) WHERE car.id =' + entityData.Id + ' GROUP BY car.id, car.Name, make.Name, model.Name  ';
            dbConnection.getResult(sqlQuery).then(function (response) {
                if (response.data.length > 0) {
                    const temp = response.data.map((car) => {
                        if(car.image[0] != null){
                            newImage = car.image.map((image) => {
                                return "http://localhost:"+settings.server.PORT +"/images/" + image;
                            });
                            car.image = [...newImage];
                            return car;
                        }
                        else{
                          return car;
                        }
                    })
                    return resolve({
                        status: HttpStatusCode.StatusCodes.OK,
                        data: response,
                        message: 'Record listed successfully!!!'
                    });
                } else {
                    return resolve({
                        status: HttpStatusCode.StatusCodes.OK,
                        data: [],
                        message: 'No record found!!!'
                    });
                }                
            })
            .catch(function (error) {
                res.status(error.status).json({
                    data: error.data
                });
            });
        });
    }

    validateFields(req, res).then(function (response) {
        getCarById(req, response.data).then(function (response) {
            res.status(response.status).json({
                data: response.data.data,
                message: response.message
            });
        })
        .catch(function (error) {
            res.status(error.status).json({
                data: error.data
            });
        });
    })
    .catch(function (error) {
        res.status(error.status).json({
            data: error.data
        });
    });
    
}