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

CREATE TABLE tb_document_type (
    id_document_type UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    document_type_description TEXT NOT NULL
);

INSERT INTO tb_document_type (id_document_type, document_type_description)
VALUES 
    (gen_random_uuid(), 'PRP'),
    (gen_random_uuid(), 'TAR'),
    (gen_random_uuid(), 'Others');



CREATE TABLE tb_profile_risk (
    id_profile_risk UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    profile_description TEXT NOT NULL,
    risk_value NUMERIC NOT NULL,
    is_active BOOLEAN NOT NULL DEFAULT TRUE
);

INSERT INTO tb_profile_risk (profile_description, risk_value, is_active)
VALUES 
    ('Conservador', 1, TRUE),
    ('Moderada', 2, TRUE),
    ('Risco Não Cadastrado', 0, TRUE),
    ('Sofisticado', 5, TRUE);


-- Inserir alguns registros na tabela Client
INSERT INTO tb_account (client_name, cpf, rg, date_birth, address, phone, email, accountNumber)
VALUES 
('John Smith', '123.456.789-01', '12.345.678-9', '1985-07-14', '123 Main Street, New York, NY', '(555) 123-4567', 'john.smith@example.com', '123456789'),
('Jane Doe', '987.654.321-00', '98.765.432-1', '1990-05-20', '456 Oak Avenue, Los Angeles, CA', '(555) 987-6543', 'jane.doe@example.com', '987654321'),
('Michael Johnson', '111.222.333-44', '22.333.444-5', '1978-03-12', '789 Pine Road, Chicago, IL', '(555) 111-2222', 'michael.j@example.com', '111222333'),
('Emily Davis', '555.666.777-88', '55.666.777-9', '1995-09-10', '101 Maple Lane, Seattle, WA', '(555) 555-6666', 'emily.davis@example.com', '555666777'),
('William Brown', '999.888.777-66', '99.888.777-6', '1982-12-25', '202 Elm Street, Austin, TX', '(555) 999-8888', 'william.brown@example.com', '999888777');
