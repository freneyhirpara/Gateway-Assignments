const Pool = require('pg').Pool
const pool = new Pool({
  user: 'postgres',
  host: 'localhost',
  database: 'DB_Car',
  password: 'Freney',
  port: 5432,
})


const getCars = (request, response) => {
  pool.query('SELECT car.id, car.Name AS Car_Name, make.Name AS Make_Name, model.Name AS Model_Name FROM car JOIN make ON (car.makeid=make.id) JOIN model ON (car.modelid=model.id) ORDER BY car.id ASC;', (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}


const getCarById = (request, response) => {
  const id = parseInt(request.params.id)

  pool.query('SELECT car.id, car.Name AS Car_Name, make.Name AS Make_Name, model.Name AS Model_Name FROM car JOIN make ON (car.makeid=make.id) JOIN model ON (car.modelid=model.id) WHERE car.id = $1', [id], (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}

module.exports = {
  getCars,
  getCarById
}
