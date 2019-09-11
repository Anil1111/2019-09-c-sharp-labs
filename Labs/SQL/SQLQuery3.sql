
--INSERT INTO Rabbits (Age, Name)
--VALUES (1, 'Billy')

----SELECT * FROM Rabbits WHERE RabbitId = 2

use RabbitDb
go

insert into Rabbits (Age, Name) values (0, 'Mary')

select * from Rabbits

UPDATE Rabbits SET Name = 'Bob' where RabbitId < 17

select * from Rabbits

delete top (1) from Rabbits

select * from Rabbits