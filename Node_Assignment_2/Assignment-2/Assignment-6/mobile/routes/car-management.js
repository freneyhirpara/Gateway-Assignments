var express = require("express");
var multer  = require('multer');
var router = express.Router({
  caseSensitive: true,
});
var ensureToken = require('../../utilities/ensure-token.js');



var storage = multer.diskStorage({
    destination: (req, file, cb) => {
      cb(null, './public/images');
    },
    filename: (req, file, cb) => {
      //console.log(file);
      var filetype = '';
      if(file.mimetype === 'image/gif') {
        filetype = 'gif';
      }
      if(file.mimetype === 'image/png') {
        filetype = 'png';
      }
      if(file.mimetype === 'image/jpeg') {
        filetype = 'jpg';
      }
      cb(null, 'image-' + Date.now() + '.' + filetype);
    }
});
var upload = multer({ storage: storage });




/**
 *  Get All Users
 */
var getAllCarsCtrl = require('../controllers/car-management/get-all-cars.js');
router.get("/cars", ensureToken, function (req, res) {
  return getAllCarsCtrl.getAllCars(req, res);
});

/**
 *  Get User By Id
 */
var getCarByIdCtrl = require("../controllers/car-management/get-car-by-id.js");
router.get("/:id", ensureToken, function (req, res) {
  return getCarByIdCtrl.getCarById(req, res);
});

/**
 *  Post Car
 */
var postCarCtrl = require('../controllers/car-management/create-car.js');
router.post("/cars", ensureToken, function (req, res) {
  return postCarCtrl.createCar(req, res);
});


/**
 *  Put Car
 */
var putUpdatedCarCtrl = require('../controllers/car-management/update-car.js');
router.put("/cars/:id", ensureToken, function (req, res) {
  return putUpdatedCarCtrl.updateCar(req, res);
});

/**
 *  Delete Car
 */
var deleteCarCtrl = require('../controllers/car-management/delete-car.js');
router.delete("/cars/:id", ensureToken, function (req, res) {
  return deleteCarCtrl.deleteCar(req, res);
});

/**
 *  Upload Car Image
 */
var uploadImageCtrl = require('../controllers/car-management/upload-image.js');
router.post("/upload/:id", ensureToken,upload.single('carimage'), function (req, res) {
  return uploadImageCtrl.uploadImage(req, res);
});
module.exports = router;