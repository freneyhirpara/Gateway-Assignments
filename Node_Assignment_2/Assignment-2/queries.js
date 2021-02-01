const Pool = require('pg').Pool
const pool = new Pool({
  user: 'postgres',
  host: 'localhost',
  database: 'DB_Car',
  password: 'Freney',
  port: 5432,
})

//Get All Cars
const getCars = (request, response) => {
  pool.query('SELECT car.id, car.Name AS Car_Name, make.Name AS Make_Name, model.Name AS Model_Name, array_agg(carimage.imagename) as image FROM car LEFT JOIN make ON (car.makeid=make.id) LEFT JOIN model ON (car.modelid=model.id) LEFT JOIN carimage ON (car.id=carimage.carid) GROUP BY car.id, car.Name, make.Name, model.Name  ORDER BY car.id ASC ;', (error, results) => {
    if (error) {
      throw error
    }
    const temp = results.rows.map((car) => {
      if(car.image[0] != null){
          newImage = car.image.map((image) => {
              return "http://localhost:3002/uploads/images/" + image;
          });
          car.image = [...newImage];
          return car;
      }
      else{
        return car;
      }
    })
      response.status(200).json(results.rows)
  })
}

//Get car by id
const getCarById = (request, response) => {
  const id = parseInt(request.params.id)

  pool.query('SELECT car.id, car.Name AS Car_Name, make.Name AS Make_Name, model.Name AS Model_Name, array_agg(carimage.imagename) as image FROM car LEFT JOIN make ON (car.makeid=make.id) LEFT JOIN model ON (car.modelid=model.id) LEFT JOIN carimage ON (car.id=carimage.carid) WHERE car.id = $1 GROUP BY car.id, car.Name, make.Name, model.Name  ', [id], (error, results) => {
    if (error) {
      throw error
    }
    const temp = results.rows.map((car) => {
      if(car.image[0] != null){
          newImage = car.image.map((image) => {
              return "http://localhost:3002/uploads/images/" + image;
          });
          car.image = [...newImage];
          return car;
      }
      else{
        return car;
      }
    })
    response.status(200).json(results.rows)
  })
}

//Post Car
const createCar = (request, response) => {
  let CarName  = request.body.Name;
  let makename = request.body.makename;
  let modelname = request.body.modelname;
  pool.query('SELECT Name from car WHERE Name=$1',[CarName],(error,results)=>{
    if(results.rowCount==0){
      pool.query('SELECT name from make where name = $1', [makename], (error, results) => {
        if (results.rowCount==0) {
          pool.query('INSERT INTO make (name) VALUES ($1)', [makename], (error, results) => {
            if (error) {
              throw error
            }
         })
        }
     })
     

     pool.query('SELECT name from model where name = $1', [modelname], (error, results) => {
      if (results.rowCount==0) {
        pool.query('INSERT INTO model (name) VALUES ($1)', [modelname], (error, results) => {
          if (error) {
            throw error
          }
       })
      }
     })

     pool.query('SELECT id from make WHERE name = $1',[makename],(error,results)=>{
      if(error){
        throw error
      }
        makeid = results.rows[0].id
        pool.query('SELECT id from model WHERE name = $1',[modelname],(error,result)=>{
      
          modelid = result.rows[0].id
          pool.query('INSERT INTO car (Name, makeid,modelid) VALUES ($1, $2, $3)', [CarName,makeid,modelid], (error, results) => {
            if (error) {
              throw error
            }
            response.status(201).send(`car added successfully`)
         })
        
      })  
    })  
    }
    else{
      response.status(201).send(`car with similar Name already exist.`)
    }
  })
}
 //Update Car Details by id
const updateCar = (request, response) => {
      let id = request.params.id;
      let CarName  = request.body.Name;
      let makename = request.body.makename;
      let modelname = request.body.modelname;
      pool.query('SELECT Name from car WHERE Name=$1',[CarName],(error,results)=>{
        if(results.rowCount==0){
          pool.query('SELECT name from make where name = $1', [makename], (error, results) => {
            if (results.rowCount==0) {
              pool.query('INSERT INTO make (name) VALUES ($1)', [makename], (error, results) => {
                if (error) {
                  throw error
                }
             })
            }
         })
         
    
         pool.query('SELECT name from model where name = $1', [modelname], (error, results) => {
          if (results.rowCount==0) {
            pool.query('INSERT INTO model (name) VALUES ($1)', [modelname], (error, results) => {
              if (error) {
                throw error
              }
           })
          }
         })
    
         pool.query('SELECT id from make WHERE name = $1',[makename],(error,results)=>{
          if(error){
            throw error
          }
            makeid = results.rows[0].id
            pool.query('SELECT id from model WHERE name = $1',[modelname],(error,result)=>{
          
              modelid = result.rows[0].id
              pool.query('UPDATE car SET Name=$1, makeid=$2,modelid=$3 WHERE id=$4', [CarName,makeid,modelid,id], (error, results) => {
                if (error) {
                  throw error
                }
                response.status(201).send(`car updated successfully`)
             })
            
          })
        })
        
           
        }
        else{
          response.status(201).send(`Car with similar Name already exist.`)
        }
      })
}

//Delete Car
const deleteCar = (request, response) => {
  const id = parseInt(request.params.id)

  pool.query('DELETE FROM car WHERE id = $1', [id], (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).send(`Car deleted with ID: ${id}`)
  })
}

const uploadImage = (req,res)=>{
  const id= parseInt(req.params.id);
  
  var currentdate = new Date();
  
  if (!req.file) {
    res.status(500).send('file not found');

  } 
  let filename = req.file.filename;




  pool.query('SELECT  id FROM car WHERE id=$1',[id],(error,result)=>{
    if(result.rowCount!=0){
      pool.query('INSERT INTO carimage (carid,imagename,createdate) VALUES ($1,$2,$3)', [id,filename,currentdate], (error, results) => {
        if (error) {
          throw error
        }
        else{
          res.json({ fileUrl: 'http://localhost:3002/uploads/images/' + req.file.filename });

        }
          })
          
    }
    else{
      res.send('Car does not exist.')
      
    }
  })
}




module.exports = {
  getCars,
  getCarById,
  createCar,
  updateCar,
  deleteCar,
  uploadImage
}



// var multer  = require('multer');
// var storage = multer.diskStorage({
//     destination: (req, file, cb) => {
//       cb(null, './uploads/images');
//     },
//     filename: (req, file, cb) => {
//       //console.log(file);
//       var filetype = '';
//       if(file.mimetype === 'image/gif') {
//         filetype = 'gif';
//       }
//       if(file.mimetype === 'image/png') {
//         filetype = 'png';
//       }
//       if(file.mimetype === 'image/jpeg') {
//         filetype = 'jpg';
//       }
//       cb(null, 'image-' + Date.now() + '.' + filetype);
//     }
// });
// var upload = multer({ storage: storage });





// app.post('/upload/:id', upload.single('profilepicture'), function (req, res, next) {
//   const id = parseInt(req.params.id);

//   if (!req.file) {
//     res.status(500);
//     return next(err);
//   } 
//   //let filename = req.file.filename
  
  
//   //db.callback(id, filename);
  
//   res.json({ fileUrl: 'http://localhost:3000/images/' + req.file.filename });
// })














// Assignment-3 :
// 1. Create API to add car record
//   - Parameter => Car Name, Model Name, Model Name
//  - Validate following things:
//   a. Car Name => Is it already added or not? if exist then response "Car Already exist".
//   b. Make Name => If make name is already exist => Take make Id and store to Car table. 
//    If it is new then get new Id and store in Car table.
//   c. Model Name => If model name is already exist => Take model Id and store to Car table. 
//    If it is new then get new Id and store in Car table.

// 2. Update car details API
//  - Parameter => Id, Car Name, Model Name, Model Name
//  - Validate following things:
//   a. Car Name => Is it already added or not? if exist then response "Car Already exist".
//   b. Make Name => If make name is already exist => Take make Id and store to Car table. 
//    If it is new then get new Id and store in Car table.
//   c. Model Name => If model name is already exist => Take model Id and store to Car table. 
//    If it is new then get new Id and store in Car table.
// 3. Delete Car API
//   - Parameter => Id