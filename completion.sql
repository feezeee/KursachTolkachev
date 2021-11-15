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

insert into workers (last_name, first_name, middle_name, phone_number, email, password, position_id, qualification_id, access_right_id) values
("Кириленко", "Наталья", "Геннадьевна", "+375297654321", "йцукенгшщзхъ", "root", 3, 1, 1);

insert into subjects (subject_name, worker_id) values
("Математика", 2),
("Физика", 2),
("Химия", 2);

insert into classes_char (char_name) values
("А"),
("Б"),
("В");

insert into classes_type (type_number) values
(1),
(2),
(3),
(4),
(5),
(6),
(7),
(8),
(9),
(10),
(11);

insert into classes (class_type_id, classroom_teacher_worker_id, class_char_id ) values
(1, 1, 2),
(10, 1, 2),
(2, 1, 2);

insert into students (last_name, first_name, middle_name, class_id) values
("Ученик1ф", "Ученик1и", "Ученик1о", 1),
("Ученик2ф", "Ученик2и", "Ученик2о", 2);


insert into schedules (date, class_id, subject_id) values
("2021-11-12 01:05:47", 1, 1),
("2021-11-11 01:05:47", 1, 2),
("2021-11-9 01:05:47", 1, 3);
