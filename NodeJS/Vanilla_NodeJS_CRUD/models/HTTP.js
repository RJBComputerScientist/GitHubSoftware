  const Enum = {
    GET: "GET",
    POST: "POST",
    PUT: "PUT",
    DELETE: "DELETE",
}
Object.freeze(Enum) // Object cant be changed
// ^^ not needed in some cases
module.exports = Enum