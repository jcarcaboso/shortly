begin;

CREATE SCHEMA dbo;

create table dbo."short_url_mapping"
(
    id text PRIMARY KEY,
    url text not null,
    creation_date timestamp not null default now(),
    is_active boolean not null default true
);

commit;