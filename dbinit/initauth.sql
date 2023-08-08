create table if not exists public.deliveryservice_auth_token
(
    deliveryservice_auth_token_id serial not null,
    session_token_guid varchar(50) unique not null,
    begin_datetime timestamp with time zone not null,
    end_datetime timestamp with time zone not null
);
create unique index deliveryservice_auth_token_guid_idx ON public.deliveryservice_auth_token (session_token_guid);
