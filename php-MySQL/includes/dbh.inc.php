<!-- Here I will create a datasource variable -->
<!-- MySQLConnection has bad security, MySQLConnectionI has better security than the original -->
<!-- $pdo stands for php data objects. Another way to connect to databases which is really flexible -->
<?php

$dsn = "mysql:host=localhost;dbname=test";
$dbusername = "root";
$dbpassword = "";

try {
    $pdo = new PDO($dsn, dbusername, dbpassword);
    $pdo -> setAttribute(pdo::ATTR_ERRMODE, pdo::ATTR_ERRMODE_EXCEPTION);
} catch (PDOException $e) {
    echo "Connection failed: " . $e->getMessage();
}