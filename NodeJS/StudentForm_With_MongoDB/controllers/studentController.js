const express = require('express');
var router = express.Router();
const mongoose = require('mongoose');
const Student = require('Student');

router.get('/', (req, res) => {
    res.render('student/addOrEdit', {
        viewTitle: 'Insert Student'
    });
});

router.post('/', (req, res) => {
    if(req.body._id == ''){
        insertRecord(req, res);
    } else {
        updateRecord(req, res);
    }
})