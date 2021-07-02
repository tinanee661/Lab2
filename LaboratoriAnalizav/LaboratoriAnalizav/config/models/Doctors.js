const mongoose = require('mongoose');

const DoctorSchema = mongoose.Schema({
    name: String,
    email: String,
    phone: Number,
    description: String,
    updated_date: { type: Date, default: Date.now },
});
module.exports = mongoose.model('Doctors', DoctorSchema);