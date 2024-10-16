create table test
(
	id int primary key,
	name varchar(255)
);


select * from test

insert into test values
(1, 'test1'),
(2, 'test2'),
(3, 'test3'),
(4, 'test4'),
(5, 'test5'),
(6, 'test6'),
(7, 'test7'),
(8, 'test8'),
(9, 'test9'),
(10, 'test10');

drop table test

select * from contacts


create table contacts
(
	id int primary key identity(1,1),
	contactname nvarchar(255) null,
	photo image null
)

drop table contacts

create table conversations
(
	id int primary key identity(1,1),
	ContactName nvarchar(255) null,
	LastOnline nchar(10) null,
	ReceivedMsgs nvarchar(max) null,
	MsgReceivedOn datetime null,
	IsReplied bit null,
	IsRead bit null,
	SentMsgs nvarchar(max) null,
	MsgSentOn datetime null,
	DocumentReceived nvarchar(max) null,
	DocumentSent nvarchar(max) null,
)

INSERT INTO conversations (ContactName, LastOnline, ReceivedMsgs, MsgReceivedOn, IsReplied, IsRead, SentMsgs, MsgSentOn, DocumentReceived, DocumentSent)
VALUES
('Steve', 'Today', 'Hey, what’s up?', '2020-09-07 10:00:00.000', NULL, NULL, NULL, NULL, NULL, NULL),
('Steve', 'Today', NULL, NULL, NULL, NULL, 'Everything is going smooth. What about you?', '2020-09-07 10:05:00.000', NULL, NULL),
('Steve', NULL, 'Same here. What’s your plan for this weekend?', '2020-09-07 10:06:00.000', NULL, NULL, NULL, NULL, NULL, NULL),
('Steve', NULL, NULL, NULL, NULL, NULL, 'Nothing much. Do you have something in mind?', '2020-09-07 10:07:00.000', NULL, NULL),
('Steve', NULL, 'I’ve been thinking about going out on a picnic since the last weekend. What do you say?', '2020-09-07 10:08:00.000', NULL, NULL, NULL, NULL, NULL, NULL),
('Steve', NULL, NULL, NULL, NULL, NULL, 'Not a bad idea. I’m up for it. Even I’ve been tired of loitering around malls and movie theaters on the weekends. Outdoors would be great. Do you’ve a location in mind?', '2020-09-07 10:09:00.000', NULL, NULL),
('Steve', NULL, 'How about Tava? It’s relatively remote and just three-hour drive. We can in fact stay a night there in the government guest house maintained by the forest department.', '2020-09-07 10:10:00.000', NULL, NULL, NULL, NULL, NULL, NULL),
('Steve', NULL, NULL, NULL, NULL, NULL, 'Can you tell more about the place? What activities we can take to there?', '2020-09-07 10:11:00.000', NULL, NULL),
('Steve', NULL, 'The guest house is located on a small hillock overlooking the backwaters of a dam. It’s picturesque. We can make the guest house our base and undertake different activities in the surrounding area.', '2020-09-07 10:12:00.000', NULL, NULL, NULL, NULL, NULL, NULL),
('Steve', NULL, NULL, NULL, NULL, NULL, 'The location sounds exciting.', '2020-09-07 10:13:00.000', NULL, NULL),
('Steve', NULL, 'We can hike down from the guest house to the backwater in an hour or so, spend some time there, then walk on a different trail, and then finally walk back up to the guest house in the evening. We can also take boat ride on the backwater, but for that we’ll have to walk 2-3 kilometers, which isn’t a big deal. There is forest all around that area, and on the next day we can loiter around. You’ll get perfect solitude in the area.', '2020-09-07 10:14:00.000', NULL, NULL, NULL, NULL, NULL, NULL),
('Steve', NULL, NULL, NULL, NULL, NULL, 'Can we cook our own food? Because that’s a key ingredient of any picnic.', '2020-09-07 10:15:00.000', NULL, NULL),
('Steve', NULL, 'I’m not sure about it. We can carry the raw material, but we can get confirmation only when we reach there.', '2020-09-07 10:16:00.000', NULL, NULL, NULL, NULL, NULL, NULL),
('Steve', NULL, NULL, NULL, NULL, NULL, 'OK.', '2020-09-07 10:17:00.000', NULL, NULL),
('Steve', NULL, 'I forgot to mention that we can even play volleyball or cricket close to the bank of the backwater, which has a sandy beach.', '2020-09-07 10:18:00.000', NULL, NULL, NULL, NULL, NULL, NULL),
('Steve', NULL, NULL, NULL, NULL, NULL, 'Sandy beach, wow!', '2020-09-07 10:19:00.000', NULL, NULL),
('Steve', NULL, 'It’s not like what you’ll get on a coastline, but it’s awesome considering the fact that it’s so close to us. OK, so what’s the plan?', '2020-09-07 10:20:00.000', NULL, NULL, NULL, NULL, NULL, NULL),
('Steve', NULL, NULL, NULL, NULL, NULL, 'I’m definitely in. Let’s ask a few more friends. We should aim for 5-6.', '2020-09-07 10:21:00.000', NULL, NULL),
('Steve', NULL, 'Agree. Once we’ve people in, we can pool in different resources – food, vehicle, and other items.', '2020-09-07 10:22:00.000', NULL, NULL, NULL, NULL, NULL, NULL),
('Steve', NULL, NULL, NULL, NULL, NULL, 'Let’s speak to others today and get the final consent by tomorrow.', '2020-09-07 10:23:00.000', NULL, NULL),
('Steve', NULL, 'Sounds good.', '2020-09-07 10:24:00.000', NULL, NULL, NULL, NULL, NULL, NULL),
('Mike', NULL, 'The paper was long, wasn’t it?', '2020-09-08 11:15:00.000', NULL, NULL, NULL, NULL, NULL, NULL),
('Mike', NULL, NULL, NULL, NULL, NULL, 'Yes, unusually long. For sure, we won’t see as many 95+ marks in English this year.', '2020-09-08 11:20:00.000', NULL, NULL),
('Mike', NULL, 'How did you do?', '2020-09-08 11:25:00.000', NULL, NULL, NULL, NULL, NULL, NULL),
('Mike', NULL, NULL, NULL, NULL, NULL, 'So. So. I wish I had timed myself better. In the end, I left questions worth 10 marks unattempted. How about you?', '2020-09-08 11:30:00.000', NULL, NULL),
('Mike', NULL, 'I started off well. I was in fact ahead of time as long as I was on grammar and letter writing, but this year’s reading comprehension passages were just too tough for me, and it completely derailed my time management.', '2020-09-08 11:35:00.000', NULL, NULL, NULL, NULL, NULL, NULL),
('Mike', NULL, NULL, NULL, NULL, NULL, 'So, did you too fail to complete the paper?', '2020-09-08 11:36:00.000', NULL, NULL),
('Mike', NULL, 'I did somehow manage to complete, but in the last 20-odd minutes I had to hurry so much that I guess I made quite a few mistakes. Which parts in the paper did you find particularly challenging?', '2020-09-08 11:37:00.000', NULL, NULL, NULL, NULL, NULL, NULL),
('Mike', NULL, NULL, NULL, NULL, NULL, 'Well, English has never been my forte, and I found even parts of grammar to be challenging, besides the usual culprit – reading comprehension.', '2020-09-08 11:40:00.000', NULL, NULL),
('Mike', NULL, '(Sighs) Well, can’t do much now. Let’s hope for the best and get ready for the next one, chemistry.', '2020-09-08 11:42:00.000', NULL, NULL, NULL, NULL, NULL, NULL),
('Mike', NULL, NULL, NULL, NULL, NULL, 'You’re right. Let’s get back to studies. Few more hard days to go.', '2020-09-08 12:00:00.000', NULL, NULL);


INSERT INTO contacts (contactname, photo)
VALUES
('Mike', NULL),
('John', NULL),
('Will', NULL),
('Steve', NULL),
('Rohit', NULL),
('Liam', NULL),
('Noah', NULL),
('Oliver', NULL);


select * from contacts

select * from conversations