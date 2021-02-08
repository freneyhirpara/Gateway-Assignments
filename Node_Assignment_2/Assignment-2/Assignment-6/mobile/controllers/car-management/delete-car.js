var HttpStatusCode = require("http-status-codes");
var dbConnection = require('../../../utilities/postgresql-connection.js');
var validate = require('validator');
exports.deleteCar = function (req, res) {
    var entityData = {
        id:req.params.id
    };

    function validateFields(req, res) {
        return new Promise(function (resolve, reject) {

            var isUserIdEmpty = validate.isEmpty(entityData.id);
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
    

    function deleteCar(req, entityData) {
        return new Promise(  function (resolve, reject) {
            var carCheckQuery =  "SELECT id FROM car WHERE id ='"+ entityData.id + "'";
             dbConnection.getResult(carCheckQuery).then(async function (response) {
            if(response.data.length!=0){

            var carImageQuery =  "SELECT carid FROM carimage WHERE carid ='"+ entityData.id + "'";
            await dbConnection.getResult(carImageQuery).then( function (response) {
                if(response.data.length!=0){
                    var deleteImageQuery = "DELETE FROM carimage WHERE carid = '"+ entityData.id + "'";
                    dbConnection.getResult(deleteImageQuery).then(function (response) {
                        
                    });
                }

            })
            var sqlQuery = "DELETE FROM car WHERE id = '"+ entityData.id+ "'";
            await dbConnection.getResult(sqlQuery).then(function (response) {
                
                    return resolve({
                        status: HttpStatusCode.StatusCodes.OK,
                        message: 'Car deleted with ID: '+ entityData.id
                    })
                             
            })
        }
        else{
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
        deleteCar(req, response.data).then(function (response) {
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