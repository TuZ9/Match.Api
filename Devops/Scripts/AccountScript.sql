CREATE TABLE tb_account (
    id_account UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    client_name VARCHAR(255) NOT NULL,
    accountNumber CHAR(9) NOT NULL CHECK (accountNumber ~ '^[0-9]{9}$'), -- Ensure exactly 9 digits
    cpf CHAR(14) NOT NULL, -- Format XXX.XXX.XXX-XX
    rg VARCHAR(20) NOT NULL,
    date_birth DATE NOT NULL,
    address TEXT,
    phone VARCHAR(20),
    email VARCHAR(255)    
);

-- Inserir alguns registros na tabela Client
INSERT INTO tb_account (client_name, cpf, rg, date_birth, address, phone, email, accountNumber)
VALUES 
('John Smith', '123.456.789-01', '12.345.678-9', '1985-07-14', '123 Main Street, New York, NY', '(555) 123-4567', 'john.smith@example.com', '123456789'),
('Jane Doe', '987.654.321-00', '98.765.432-1', '1990-05-20', '456 Oak Avenue, Los Angeles, CA', '(555) 987-6543', 'jane.doe@example.com', '987654321'),
('Michael Johnson', '111.222.333-44', '22.333.444-5', '1978-03-12', '789 Pine Road, Chicago, IL', '(555) 111-2222', 'michael.j@example.com', '111222333'),
('Emily Davis', '555.666.777-88', '55.666.777-9', '1995-09-10', '101 Maple Lane, Seattle, WA', '(555) 555-6666', 'emily.davis@example.com', '555666777'),
('William Brown', '999.888.777-66', '99.888.777-6', '1982-12-25', '202 Elm Street, Austin, TX', '(555) 999-8888', 'william.brown@example.com', '999888777');
