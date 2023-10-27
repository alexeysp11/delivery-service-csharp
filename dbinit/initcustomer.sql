-- SQL script for backend service (customer app)
create table if not exists delivery_customer_cb (
    delivery_customer_cb_id serial primary key,
    customer_uid varchar(50),
    login varchar(50), 
    email varchar(255),
    phone_number varchar(50),
    password varchar(50)
);
create table if not exists delivery_customer_tmp_cb (
    delivery_customer_tmp_cb_id serial primary key,
    customer_uid varchar(50),
    login varchar(50), 
    email varchar(255),
    phone_number varchar(50),
    password varchar(50)
);
create table if not exists delivery_customer_token_cb (
    delivery_customer_token_cb_id serial primary key,
    token_guid varchar(50),
    token_begin_dt timestamp,
    token_end_dt timestamp,
    customer_id integer references delivery_customer_cb
);
create table if not exists delivery_category_cb (
    delivery_category_cb_id serial primary key,
    name varchar(150), 
    description varchar(255),
    picture bytea,
    picture_url text,
    picture_description varchar(255)
);
create table if not exists delivery_menuitem_cb (
    delivery_menuitem_cb_id serial primary key,
    name varchar(150),
    price double precision,
    description varchar(255),
    delivery_category_cb_id integer references delivery_category_cb,
    picture bytea,
    picture_url text,
    picture_description varchar(255)
);

insert into delivery_category_cb (name, description, picture_url, picture_description) values ('Breakfast', '', 'https://images.services.kitchenstories.io/PV-rl5pSp1lL_XRe7KDBW1KGan4=/3840x0/filters:quality(80)/images.kitchenstories.io/wagtailOriginalImages/R2798-photo-final-1.jpg', 'Breakfast');
insert into delivery_category_cb (name, description, picture_url, picture_description) values ('Rice bowl', '', 'https://cdn.loveandlemons.com/wp-content/uploads/2020/04/rice-bowl-recipes-500x500.jpg', 'Rice bowl');
insert into delivery_category_cb (name, description, picture_url, picture_description) values ('Salad', '', 'https://www.eatingwell.com/thmb/ZgUTobMJAI_Q-zTpj273piX18h0=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/EWL-250303-composed-salad-with-pickled-beets-smoked-tofu-Hero-02-9e2a9b7202a34d81908a4db78a927d57.jpg', 'Salad');
insert into delivery_category_cb (name, description, picture_url, picture_description) values ('Chicken', '', 'https://arc-anglerfish-washpost-prod-washpost.s3.amazonaws.com/public/T2Z7FGHEXYI6XCGFJ7LDQLCHZM.jpg', 'Chicken');
insert into delivery_category_cb (name, description, picture_url, picture_description) values ('Crezy beef', '', 'https://live.staticflickr.com/1359/998064336_9f95c07a4c_b.jpg', 'Crezy beef');
insert into delivery_category_cb (name, description, picture_url, picture_description) values ('Burger', '', 'https://www.allrecipes.com/thmb/5JVfA7MxfTUPfRerQMdF-nGKsLY=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/25473-the-perfect-basic-burger-DDMFS-4x3-56eaba3833fd4a26a82755bcd0be0c54.jpg', 'Burger');
insert into delivery_category_cb (name, description, picture_url, picture_description) values ('Cake', '', 'https://handletheheat.com/wp-content/uploads/2015/03/Best-Birthday-Cake-with-milk-chocolate-buttercream-SQUARE.jpg', 'Cake');
insert into delivery_category_cb (name, description, picture_url, picture_description) values ('Juice', '', 'https://play-lh.googleusercontent.com/9edIQw3IulBae6kreGNlm59hG4kloEGXE5bEfuoxcPGlI47Jz-ZJpl1dwO5Zn5U9UFM', 'Juice');

insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Berries', 12, '', 1);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Cold cereal', 13, '', 1);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Cottage cheese', 12, '', 1);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Eggs', 8, '', 1);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Green tea', 14, '', 1);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Oatmeals', 12, '', 1);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Peanut butter', 11, '', 1);

insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Butter chicken rice', 12, '', 2);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Chicken briyani', 13, '', 2);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Braised beef rice', 12, '', 2);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Rice bowl', 8, '', 2);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Veg briyani', 11, '', 2);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Plain rice', 11, '', 2);

insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Antipasto salad', 12, '', 3);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('BBQ pork salad', 13, '', 3);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Broccoli rabe', 12, '', 3);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Ceasar salad', 8, '', 3);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Chicken salad', 14, '', 3);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Crispy salad', 12, '', 3);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Ponir mix salad', 11, '', 3);

insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Finger chicken', 12, '', 4);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Chicken grilled', 13, '', 4);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Chicken grilled with butter', 12, '', 4);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Chicken wrap', 8, '', 4);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Chicken marsala', 14, '', 4);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Chicken francese', 12, '', 4);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Chicken prame', 11, '', 4);

insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('BBQ beef', 12, '', 5);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Beef fries', 13, '', 5);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Beef burger', 12, '', 5);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Beef grilled', 8, '', 5);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Beef meal', 14, '', 5);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Beef meat steak', 12, '', 5);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Beef bogorok', 11, '', 5);

insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Luger burger', 12, '', 6);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Le pigeon burger', 13, '', 6);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Double animal style', 12, '', 6);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('The original burger', 8, '', 6);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Whiskey king burger', 14, '', 6);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('The company burger', 12, '', 6);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Dyer''s deep-fried burger', 12, '', 6);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('The Lola burger', 11, '', 6);

insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Black forest gateau', 12, '', 7);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Pineapple cake', 11, '', 7);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Eggless truffle cake', 11, '', 7);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Coffee cake with mocha frosting', 13, '', 7);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Fudgy chocolate cake', 11, '', 7);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Mango meringue cake', 12, '', 7);

insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Orange juice', 12, '', 8);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Lemonade', 8, '', 8);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Apple juice', 13, '', 8);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Grape juice', 15, '', 8);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Pineapple juice', 14, '', 8);
insert into delivery_menuitem_cb (name, price, description, delivery_category_cb_id) values ('Cranberry juice', 16, '', 8);
