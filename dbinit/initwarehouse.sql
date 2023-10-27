create table if not exists delivery_useraccount_whb (
    delivery_useraccount_whb_id serial primary key,
    user_account_uid varchar(50),
    login varchar(50),
    email varchar(50),
    phone_number varchar(50),
    password varchar(50),
    photo bytea,
    photo_url text,
    user_status varchar(50),
    last_seen_dt timestamp with time zone,
);
create table if not exists delivery_employee_whb (
    delivery_employee_whb_id serial primary key,
    employee_uid varchar(50),
    first_name varchar(150),
    middle_name varchar(150),
    last_name varchar(150),
    full_name varchar(150),
    mobile_phone varchar(150),
    work_phone varchar(150),
    user_account_id integer references delivery_useraccount_whb,
);
create table if not exists delivery_category_whb (
    delivery_category_whb_id serial primary key,
    name varchar(150), 
    description varchar(255),
    picture bytea,
    picture_url text,
    picture_description varchar(255)
);
create table if not exists delivery_menuitem_whb (
    delivery_menuitem_whb_id serial primary key,
    name varchar(150),
    price double precision,
    description varchar(255),
    delivery_category_whb_id integer references delivery_category_whb,
    picture bytea,
    picture_url text,
    picture_description varchar(255)
);
create table if not exists delivery_whproduct_whb (
    delivery_whproduct_whb_id serial primary key,
    whproduct_uid varchar(50),
    name varchar(150),
    menuitem_whb_id integer references delivery_menuitem_whb
);
