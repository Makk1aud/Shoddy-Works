USE shoddy_works;
CREATE TABLE Client (
    client_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    firstname VARCHAR(20) NOT NULL,
    lastname VARCHAR(20) NULL,
    login VARCHAR(20) NOT NULL UNIQUE,
    password VARCHAR(20) NOT NULL,
    email VARCHAR(30) NOT NULL,
    ref_client_id INT NULL,
    soc_media VARCHAR(150) NULL,
    FOREIGN KEY (ref_client_id)
        REFERENCES Client (client_id)
);

CREATE TABLE Mentor (
    mentor_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    firstname VARCHAR(20) NOT NULL,
    lastname VARCHAR(20) NULL,
    login VARCHAR(20) NOT NULL UNIQUE,
    password VARCHAR(20) NOT NULL,
    email VARCHAR(30) NOT NULL,
    phone VARCHAR(30) NULL UNIQUE,
    soc_media VARCHAR(150) NULL
);

CREATE TABLE OrderStatus (
    order_st_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    status_title VARCHAR(30) NOT NULL
);

CREATE TABLE OfferType (
    offer_type_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    type_title VARCHAR(50) NOT NULL
);

CREATE TABLE Offer (
    offer_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    offer_title VARCHAR(50) NOT NULL,
    offer_desc VARCHAR(150) NOT NULL,
    offer_type_id INT NOT NULL,
    offer_price DECIMAL(10 , 2 ) NOT NULL,
    publish_date DATETIME NOT NULL,
    CONSTRAINT FK_offer_type_id_Offer FOREIGN KEY (offer_type_id)
        REFERENCES OfferType (offer_type_id)
);

CREATE TABLE ClientOrder (
    cl_order_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    client_id INT NOT NULL,
    mentor_id INT NOT NULL,
    order_st_id INT NOT NULL,
    offer_id INT NOT NULL,
    start_date DATETIME NOT NULL,
    end_date DATETIME NULL,
    CONSTRAINT FK_client_id_Offer FOREIGN KEY (client_id)
        REFERENCES Client (client_id),
    CONSTRAINT FK_mentor_id_Offer FOREIGN KEY (mentor_id)
        REFERENCES Mentor (mentor_id),
    CONSTRAINT FK_order_st_id_Offer FOREIGN KEY (order_st_id)
        REFERENCES OrderStatus (order_st_id),
    CONSTRAINT FK_offer_id_Offer FOREIGN KEY (offer_id)
        REFERENCES Offer (offer_id)
);