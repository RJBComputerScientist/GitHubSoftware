const express = require('express');
const router = express.Router();
const { registerUser, loginUser, currentUser } = require("../controllers/userController");

// router.route("/").get(getContacts).post(createContact);
// router.route("/:id").get(getContact).put(updateContact).delete(deleteContact);
router.post("/register", registerUser);
router.post("/login", loginUser);
router.get("/current", currentUser);

module.exports = router;