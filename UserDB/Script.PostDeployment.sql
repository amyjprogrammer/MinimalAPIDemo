if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName, LastName)
	values ('Amy', 'Jones'),
	('Tim', 'Corey'),
	('John', 'Smith'),
	('Mary','Doe');
end

/* adds dummy data, but will not run once you have a record */