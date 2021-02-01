const express = require('express')
const bodyParser = require('body-parser')
const db = require('./queries')

const app = express()
const port = 3002
app.use('/uploads', express.static('./uploads'));
app.use(bodyParser.json())
app.use(
  bodyParser.urlencoded({
    extended: true,
  })
)


var multer  = require('multer');
var storage = multer.diskStorage({
    destination: (req, file, cb) => {
      cb(null, './uploads/images');
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



app.get('/', (request, response) => {
  response.json({ info: 'Node.js, Express, and Postgres API' })
})
app.get('/cars', db.getCars)
app.get('/cars/:id', db.getCarById)
app.post('/cars', db.createCar)
app.put('/cars/:id', db.updateCar)
app.delete('/cars/:id', db.deleteCar)
app.post('/upload/:id',upload.single('carimage'), db.uploadImage); 
  





app.listen(port, () => {
  console.log(`App running on port ${port}.`)
})
