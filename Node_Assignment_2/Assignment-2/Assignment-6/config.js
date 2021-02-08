module.exports = {
    dbConnection: {
        user: "postgres",
        password: "Freney",
        host: "localhost",
        database: "DB_Car",
        port: 5432
    },
    server: {
        PORT: 3000,
    },
    jwtConfig: {
        algorithm: "HS256",
        secretKey: "Test@12345",
    },
    defaultLanguage: 1033,
    language: {
        english: 1033,
        swedish: 1053,
        danish: 1030
    }

};