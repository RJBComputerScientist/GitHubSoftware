const asyncHandler = require("express-async-handler");
const Contact = require("../models/contactModel");
/** 
 * @description Get All Contacts
 * @requires GET /api/contacts
 * @access private
 */
const getContacts = asyncHandler(async(req, res) => {
    const contacts = await Contact.find({ user_id: req.user.id });
    res.status(200).json(contacts)
});

/** 
 * @description Create A Contact
 * @requires POST /api/contacts
 * @access private
 */
const createContact = asyncHandler(async(req, res) => {
    console.log("The Request Body Is: ", req.body);
    const { name, email, phone } = req.body;
    if(!name || !email || !phone){
        res.status(400);
        throw new Error("All Fields Are Mandatory!")
    }
    const contact = await Contact.create({
        name, email, phone, user_id: req.user.id
    });
    res.status(201).json(contact);
});

/** 
 * @description Get Contact
 * @requires GET /api/contacts/:id
 * @access private
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
 * @access private
 */
const updateContact = asyncHandler(async(req, res) => {
    const contact = await Contact.findById(req.params.id);
    if(!contact){
        res.status(404);
        throw new Error("Contact Not Found");
    }

    if(contact.user_id.toString() !== req.user.id){
        res.status(403);
        throw new Error("User Doesn't Have Permission To Update Other User Contacts");
    };

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
 * @access private
 */
const deleteContact = asyncHandler(async(req, res) => {
    const contact = await Contact.findById(req.params.id);
    if(!contact){
        res.status(404);
        throw new Error("Contact Not Found");
    }
    if(contact.user_id.toString() !== req.user.id){
        res.status(403);
        throw new Error("User Doesn't Have Permission To Update Other User Contacts");
    };
    await Contact.deleteOne({_id: req.params.id});
    res.status(200).json(contact)
});

module.exports = { 
    getContacts, createContact,
    getContact, updateContact,
    deleteContact };