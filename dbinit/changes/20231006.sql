alter table delivery_category_cb add column picture_url text;
alter table delivery_category_cc add column picture_url text;
alter table delivery_category_cb add column picture_description varchar(255);
alter table delivery_category_cc add column picture_description varchar(255);

update delivery_category_cc 
set 
    picture_url = 'https://images.services.kitchenstories.io/PV-rl5pSp1lL_XRe7KDBW1KGan4=/3840x0/filters:quality(80)/images.kitchenstories.io/wagtailOriginalImages/R2798-photo-final-1.jpg', 
    picture_description = 'Breakfast'
where name = 'Breakfast';
update delivery_category_cc 
set 
    picture_url = 'https://cdn.loveandlemons.com/wp-content/uploads/2020/04/rice-bowl-recipes-500x500.jpg', 
    picture_description = 'Rice bowl'
where name = 'Rice bowl';
update delivery_category_cc 
set 
    picture_url = 'https://www.eatingwell.com/thmb/ZgUTobMJAI_Q-zTpj273piX18h0=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/EWL-250303-composed-salad-with-pickled-beets-smoked-tofu-Hero-02-9e2a9b7202a34d81908a4db78a927d57.jpg', 
    picture_description = 'Salad'
where name = 'Salad';
update delivery_category_cc 
set 
    picture_url = 'https://arc-anglerfish-washpost-prod-washpost.s3.amazonaws.com/public/T2Z7FGHEXYI6XCGFJ7LDQLCHZM.jpg', 
    picture_description = 'Chicken'
where name = 'Chicken';
update delivery_category_cc 
set 
    picture_url = 'https://live.staticflickr.com/1359/998064336_9f95c07a4c_b.jpg', 
    picture_description = 'Crezy beef'
where name = 'Crezy beef';
update delivery_category_cc 
set 
    picture_url = 'https://www.allrecipes.com/thmb/5JVfA7MxfTUPfRerQMdF-nGKsLY=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/25473-the-perfect-basic-burger-DDMFS-4x3-56eaba3833fd4a26a82755bcd0be0c54.jpg', 
    picture_description = 'Burger'
where name = 'Burger';
update delivery_category_cc 
set 
    picture_url = 'https://handletheheat.com/wp-content/uploads/2015/03/Best-Birthday-Cake-with-milk-chocolate-buttercream-SQUARE.jpg', 
    picture_description = 'Cake'
where name = 'Cake';
update delivery_category_cc 
set 
    picture_url = 'https://play-lh.googleusercontent.com/9edIQw3IulBae6kreGNlm59hG4kloEGXE5bEfuoxcPGlI47Jz-ZJpl1dwO5Zn5U9UFM', 
    picture_description = 'Juice'
where name = 'Juice';

update delivery_category_cb 
set 
    picture_url = 'https://images.services.kitchenstories.io/PV-rl5pSp1lL_XRe7KDBW1KGan4=/3840x0/filters:quality(80)/images.kitchenstories.io/wagtailOriginalImages/R2798-photo-final-1.jpg', 
    picture_description = 'Breakfast'
where name = 'Breakfast';
update delivery_category_cb 
set 
    picture_url = 'https://cdn.loveandlemons.com/wp-content/uploads/2020/04/rice-bowl-recipes-500x500.jpg', 
    picture_description = 'Rice bowl'
where name = 'Rice bowl';
update delivery_category_cb 
set 
    picture_url = 'https://www.eatingwell.com/thmb/ZgUTobMJAI_Q-zTpj273piX18h0=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/EWL-250303-composed-salad-with-pickled-beets-smoked-tofu-Hero-02-9e2a9b7202a34d81908a4db78a927d57.jpg', 
    picture_description = 'Salad'
where name = 'Salad';
update delivery_category_cb 
set 
    picture_url = 'https://arc-anglerfish-washpost-prod-washpost.s3.amazonaws.com/public/T2Z7FGHEXYI6XCGFJ7LDQLCHZM.jpg', 
    picture_description = 'Chicken'
where name = 'Chicken';
update delivery_category_cb 
set 
    picture_url = 'https://live.staticflickr.com/1359/998064336_9f95c07a4c_b.jpg', 
    picture_description = 'Crezy beef'
where name = 'Crezy beef';
update delivery_category_cb 
set 
    picture_url = 'https://www.allrecipes.com/thmb/5JVfA7MxfTUPfRerQMdF-nGKsLY=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/25473-the-perfect-basic-burger-DDMFS-4x3-56eaba3833fd4a26a82755bcd0be0c54.jpg', 
    picture_description = 'Burger'
where name = 'Burger';
update delivery_category_cb 
set 
    picture_url = 'https://handletheheat.com/wp-content/uploads/2015/03/Best-Birthday-Cake-with-milk-chocolate-buttercream-SQUARE.jpg', 
    picture_description = 'Cake'
where name = 'Cake';
update delivery_category_cb 
set 
    picture_url = 'https://play-lh.googleusercontent.com/9edIQw3IulBae6kreGNlm59hG4kloEGXE5bEfuoxcPGlI47Jz-ZJpl1dwO5Zn5U9UFM', 
    picture_description = 'Juice'
where name = 'Juice';
