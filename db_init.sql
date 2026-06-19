CREATE DATABASE IF NOT EXISTS worktest CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE worktest;

CREATE TABLE IF NOT EXISTS employees (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    full_name VARCHAR(255) NOT NULL,
    position VARCHAR(50) NOT NULL,
    date_of_birth DATE NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS contractors (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    inn VARCHAR(12) NOT NULL,
    curator_id INT NULL,
    CONSTRAINT fk_contractor_curator FOREIGN KEY (curator_id) REFERENCES employees(id) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS orders (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    date DATE NOT NULL,
    amount DECIMAL(18,2) NOT NULL,
    employee_id INT NOT NULL,
    contractor_id INT NOT NULL,
    CONSTRAINT fk_order_employee FOREIGN KEY (employee_id) REFERENCES employees(id),
    CONSTRAINT fk_order_contractor FOREIGN KEY (contractor_id) REFERENCES contractors(id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
