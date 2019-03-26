USE HealthCatalystDemo
GO

DELETE PersonsInterests
GO

DELETE Interests
GO

DELETE Persons
GO

SET IDENTITY_INSERT Persons ON
GO

INSERT INTO Persons (Id, FirstName, LastName, Address, City, State, Zip, Birthday, PictureUrl)
VALUES
(1, 'Andy', 'Alpaca', '1 1st St.', 'San Francisco', 'CA', '94111', '1/1/1971', 'alpaca.jpg'),
(2, 'Bianca', 'Bee', '2 2nd Ave.', 'Oakland', 'CA', '94577', '2/2/1982', 'bee.jpg'),
(3, 'Carol', 'Cat', '3 3rd Blvd.', 'Daly City', 'CA', '94014', '3/3/1933', 'cat.jpg'),
(4, 'Diana', 'Dolphin', '4 4th Lane', 'San Rafael', 'CA', '94901', '4/4/1944', 'dolphin.jpg'),
(5, 'Evelyn', 'Elephant', '5 5th Road', 'Berkeley', 'CA', '94701', '5/5/1955', 'elephant.jpg'),
(6, 'Fred', 'Fish', '6 6th St.', 'San Francisco', 'CA', '94110', '6/6/1966', 'fish.jpg'),
(7, 'Galvin', 'Gecko', '7 7th Ave.', 'Oakland', 'CA', '94604', '7/7/1977', 'gecko.jpg'),
(8, 'Harvey', 'Hamster', '8 8th Blvd.', 'Daly City', 'CA', '94107', '8/8/1988', 'hamster.jpg'),
(9, 'Ivana', 'Insect', '9 9th Lane', 'San Rafael', 'CA', '94974', '9/9/1999', 'insect.jpg'),
(10, 'Janice', 'Jellyfish', '10 10th Road', 'Berkeley', 'CA', '94720', '10/10/2010', 'jellyfish.jpg')
GO

SET IDENTITY_INSERT Persons OFF
GO

SET IDENTITY_INSERT Interests ON
GO

INSERT INTO Interests (Id, Interest)
VALUES
(1, 'Archery'),
(2, 'Beekeeping'),
(3, 'Chess'),
(4, 'Dancing'),
(5, 'Electronics'),
(6, 'Fishing'),
(7, 'Genealogy'),
(8, 'Hiking'),
(9, 'Internet'),
(10, 'Juggling'),
(11, 'Karaoke'),
(12, 'Legos'),
(13, 'Music'),
(14, 'Needlepoint'),
(15, 'Origami'),
(16, 'Photography'),
(17, 'Quilting'),
(18, 'Relaxing'),
(19, 'Skiing'),
(20, 'Tennis')
GO

SET IDENTITY_INSERT Interests OFF
GO

-- Randomly match persons to interests; enter data into table PersonsInterests
DECLARE @MinRowsInPersonsInterests int = 30
DECLARE @MaxRowsInPersonsInterests int = 40
DECLARE @MaxInterestsPerPerson int = 4
DECLARE @PersonsCount int = (SELECT COUNT(*) FROM Persons)
DECLARE @InterestsCount int = (SELECT COUNT(*) FROM Interests)
DECLARE @PersonId int, @InterestId int
WHILE (SELECT COUNT(*) FROM Persons WHERE Id NOT IN (SELECT DISTINCT PersonId FROM PersonsInterests)) > 0
		AND ((SELECT COUNT(*) FROM PersonsInterests) > @MinRowsInPersonsInterests
			OR (SELECT COUNT(*) FROM PersonsInterests) < @MaxRowsInPersonsInterests)
BEGIN
	SET @PersonId = FLOOR(RAND() * @PersonsCount) + 1
	SET @InterestId = FLOOR(RAND() * @InterestsCount) + 1
	IF (SELECT COUNT(*) FROM PersonsInterests WHERE PersonId = @PersonId AND InterestId = @InterestId) = 0
		AND (SELECT COUNT(*) FROM PersonsInterests WHERE PersonId = @PersonId) < @MaxInterestsPerPerson
		INSERT INTO PersonsInterests (PersonId, InterestId) VALUES (@PersonId, @InterestId) 
END
GO

