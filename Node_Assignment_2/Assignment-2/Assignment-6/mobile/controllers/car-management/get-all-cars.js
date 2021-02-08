var HttpStatusCode = require("http-status-codes");
var dbConnection = require('../../../utilities/postgresql-connection.js');
var settings = require('../../../config.js');

exports.getAllCars = function (req, res) {
    var entityData = {};

    function validateFields(req, res) {
        return new Promise(function (resolve, reject) {
            
            return resolve({
                status: HttpStatusCode.StatusCodes.OK,
                data: entityData
            });
        });
    }

    function getAllCars(req, entityData) {
        return new Promise(function (resolve, reject) {
            const sqlQuery = 'SELECT car.id, car.Name AS Car_Name, make.Name AS Make_Name, model.Name AS Model_Name, array_agg(carimage.imagename) as image FROM car LEFT JOIN make ON (car.makeid=make.id) LEFT JOIN model ON (car.modelid=model.id) LEFT JOIN carimage ON (car.id=carimage.carid) GROUP BY car.id, car.Name, make.Name, model.Name  ORDER BY car.id ASC ;';
            dbConnection.getResult(sqlQuery).then(function (response) {
                if (response.data.length > 0) {
                    const temp = response.data.map((car) => {
                        if(car.image[0] != null){
                            newImage = car.image.map((image) => {
                                return "http://localhost:"+ settings.server.PORT +"/images/" + image;
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
        getAllCars(req, response.data).then(function (response) {
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