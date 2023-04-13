/** 
 * @description Get All Contacts
 * @requires GET /api/contacts
 * @access public
 */
const getContacts = (req, res) => {
    res.status(200).json({ message: "Get All Contacts" })
};

/** 
 * @description Create A Contact
 * @requires POST /api/contacts
 * @access public
 */
const createContact = (req, res) => {
    console.log("The Request Body Is: ", req.body);
    const { name, email, phone } = req.body;
    if(!name || !email || !phone){
        throw new Error("All Fields Are Mandatory!")
    }
    res.status(200).json({ message: "Create Contact" })
};

/** 
 * @description Get Contact
 * @requires GET /api/contacts/:id
 * @access public
 */
const getContact = (req, res) => {
    res.status(200).json({ message: `Get Contact For ${req.params.id}` })
};

/** 
 * @description Update Contact
 * @requires PUT /api/contacts/:id
 * @access public
 */
const updateContact = (req, res) => {
    res.status(200).json({ message: `Update Full Contact For ${req.params.id}` })
};

/** 
 * @description Delete Contact
 * @requires DELETE /api/contacts/:id
 * @access public
 */
const deleteContact = (req, res) => {
    res.status(200).json({ message: `Delete Full Contact For ${req.params.id}` })
};

module.exports = { 
    getContacts, createContact,
    getContact, updateContact,
    deleteContact };