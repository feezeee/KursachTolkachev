use school;

insert into access_rights (access_right_type) values
("Администратор"),
("Ученик"),
("Учитель");


insert into positions (position_name) values
("Директор"),
("Заместитель директора"),
("Учитель");

insert into qualifications (qualification_name) values
("Филолог"),
("Математик"),
("Историк");

insert into workers (last_name, first_name, middle_name, phone_number, email, password, position_id, qualification_id, access_right_id) values
("Сиваченко", "Юлия", "Сергеевна", "+375291234567", "йцукенгшщзхъ", "root", 1, 1, 1);