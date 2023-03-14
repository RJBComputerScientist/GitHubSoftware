const express = require('express');
var router = express.Router();
const mongoose = require('mongoose');
const Student = mongoose.model('Student');

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
});

async function insertRecord(req, res) {
    var student = new Student();
    student.fullName = req.body.fullName;
    student.email = req.body.email;
    student.mobile = req.body.mobile;
    student.city = req.body.city;
    try {
        const CreateAStudent = await Student.create(student);
        console.log(CreateAStudent)
        if(!CreateAStudent) throw new Error("Couldn't Delete Student");
        res.redirect("student/list");
    } catch (err) {
        console.log('Error During Insert: '+err)
    }
};

async function updateRecord(req, res) {
    try {
        const UpdateAStudent = await Student.findOneAndUpdate({ _id: req.body._id }, req.body, { new: true });
        console.log(UpdateAStudent)
        if(!UpdateAStudent) throw new Error("Couldn't Delete Student");
        res.redirect("student/list");
    } catch (err) {
        console.log('Error During Update: ' + err);
    }
}

router.get('/list', async (req, res) => {
    try {
        const AllStudents = await Student.find({});
        console.log(AllStudents)
        if(!AllStudents) throw new Error("No Students Found");
        res.render('student/list', {
            list: AllStudents
        });
    } catch (err) {
        console.log('Error In Retrieval: ' + err)
    }
});

router.get('/:id', async (req, res) => {
    try {
        const FindAStudent = await Student.findById(req.params.id);
        console.log(FindAStudent)
        if(!FindAStudent) throw new Error("No Student Found");
        res.render('student/addOrEdit', {
            viewTitle: "Update Student", 
            student: FindAStudent
        });
    } catch (err) {
        console.log('Error In Retrieval: ' + err)
    }
});

router.get('/delete/:id', async (req, res) => {
    try {
        const DeleteAStudent = await Student.findByIdAndRemove(req.params.id);
        console.log(DeleteAStudent)
        if(!DeleteAStudent) throw new Error("Couldn't Delete Student");
        res.redirect("/student");
    } catch (err) {
        console.log("Error In Deletion " + err);
    }
});

module.exports = router;