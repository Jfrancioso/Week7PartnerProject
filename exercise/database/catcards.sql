USE master
GO

IF DB_ID('catcards') IS NOT NULL
BEGIN
    ALTER DATABASE catcards SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE catcards;
END

CREATE DATABASE catcards
GO

USE catcards
GO

BEGIN TRANSACTION

CREATE TABLE catcards (
	id int IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	img_url varchar(256) NOT NULL,  -- image URL
	fact varchar(1000) NOT NULL, -- Cat Fact
	caption varchar(256) NOT NULL, -- User-provided caption
)

COMMIT TRANSACTION

BEGIN TRANSACTION
INSERT INTO catcards (img_url, fact, caption) VALUES
('https://cat-data.netlify.app/images/siamese_cat-600x600.jpg', 'In 1879, Belgium unsuccessfully tried to use cats to deliver mail.', ''),
('https://cat-data.netlify.app/images/ragdoll-cat-sticking-out-tongue.jpg','Cats respond most readily to names that end in an "ee" sound.', ''),
('https://cat-data.netlify.app/images/cat-sniffing-candle-600x400.jpg','A cat can jump 5 times as high as it is tall.', '');
COMMIT TRANSACTION

