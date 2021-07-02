//funksionimin e node js si backend ne server
const express = require('express');
const path = require('path');
const bodyParser = require('body-parser');
const cors = require('cors');
const mongoose = require('mongoose'); //package per lidhjen me db dhe perdorim e modeleve ne mongo db

const config = require('./DB');
const doctors = require('./routes/doctors');


mongoose.Promise = global.Promise;
mongoose.connect(config.DB);

const app = express();
app.use((req, res, next) => {
    res.header('Access-Control-Allow-Origin', '*');
    next();
});

app.use(bodyParser.json());
app.use(cors());
app.use('/doctors', doctors);
var port = process.env.PORT || 4000;

app.listen(port, function() {
    console.log('NodeJS Server started on Port: https://localhost:' + port, port);
});