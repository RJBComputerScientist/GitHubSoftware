const asyncHandler = require("express-async-handler");
const Contact = require("../models/contactModel");
/** 
 * @description Get All Contacts
 * @requires GET /api/contacts
 * @access public
 */
const getContacts = asyncHandler(async(req, res) => {
    const contacts = await Contact.find();
    res.status(200).json(contacts)
});

/** 
 * @description Create A Contact
 * @requires POST /api/contacts
 * @access public
 */
const createContact = asyncHandler(async(req, res) => {
    console.log("The Request Body Is: ", req.body);
    const { name, email, phone } = req.body;
    if(!name || !email || !phone){
        res.status(400);
        throw new Error("All Fields Are Mandatory!")
    }
    const contact = await Contact.create({
        name, email, phone
    });
    res.status(201).json(contact);
});

/** 
 * @description Get Contact
 * @requires GET /api/contacts/:id
 * @access public
 */
const getContact = asyncHandler(async(req, res) => {
    const contact = await Contact.findById(req.params.id);
    if(!contact){
        res.status(404);
        throw new Error("Contact Not Found");
    }
    res.status(200).json(contact)
});

/** 
 * @description Update Contact
 * @requires PUT /api/contacts/:id
 * @access public
 */
const updateContact = asyncHandler(async(req, res) => {
    const contact = await Contact.findById(req.params.id);
    if(!contact){
        res.status(404);
        throw new Error("Contact Not Found");
    }
    const updatedContact = await Contact.findByIdAndUpdate(
        req.params.id,
        req.body,
        {new: true}
    )
    res.status(200).json(updatedContact)
});

/** 
 * @description Delete Contact
 * @requires DELETE /api/contacts/:id
 * @access public
 */
const deleteContact = asyncHandler(async(req, res) => {
    const contact = await Contact.findById(req.params.id);
    if(!contact){
        res.status(404);
        throw new Error("Contact Not Found");
    }
    await Contact.deleteOne();
    res.status(200).json(contact)
});

module.exports = { 
    getContacts, createContact,
    getContact, updateContact,
    deleteContact };