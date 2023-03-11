const mongoose = require('mongoose');
const assert = require('assert')

const connectDB = async () => {
    try {
        const conn = await mongoose.connect(process.env.MONGO_URI, {
            useNewUrlParser: true,
            useUnifiedTopology: true
        });

        console.log(`MongoDB Connected: ${conn.connection.host}`);
        // assert.ok(conn, "Connection Is Good");
    } catch (error) {
        console.error(error);
        assert.fail(error);
        // process.exit(1);
    }
}

module.exports = connectDB