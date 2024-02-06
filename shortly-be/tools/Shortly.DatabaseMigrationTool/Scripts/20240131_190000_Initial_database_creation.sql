begin;

CREATE SCHEMA shortly;

create table shortly."short_url_mapping"
(
    id text PRIMARY KEY,
    url text not null,
    creation_date timestamp not null default now(),
    is_active boolean not null default true
);

commit;