var Doctors = require('../models/Doctors');
var express = require('express');
var router = express.Router();

/* GET ALL Doctors */
router.get('/', function(req, res, next) {
    Doctors.find(function(err, doctors) {
        if (err) return next(err);
        res.json(doctors);
    });
});

/* GET SINGLE Doctor BY ID */
router.get('/:id', function(req, res, next) {
    Doctors.findById(req.params.id, function(err, doctor) {
        if (err) return next(err);
        res.json(doctor);
    });
});

/* SAVE Doctor */
router.post('/', function(req, res) {
    console.log(req.body)
    let doctor = req.body;
    doctor.name = req.body.name
    doctor.email = req.body.email
    doctor.phone = req.body.phone
    doctor.description = req.body.description

    Doctors.create(doctor, function(err, doctor) {
        if (err) return next(err);
        res.json(doctor);
    });
});

module.exports = router;