CREATE DATABASE eclipseworksappdb;

\c eclipseworksappdb;

CREATE TABLE "Users" (
    "Id"  SERIAL  NOT NULL,
    "Name" VARCHAR(80)   NOT NULL,
    "Profile" int   NOT NULL,
    CONSTRAINT "pk_Users" PRIMARY KEY (
        "Id"
     )
);

CREATE TABLE "Projects" (
    "Id"  SERIAL  NOT NULL,
    "Name" varchar(20)   NOT NULL,
    "Description" varchar(200)   NOT NULL,
    "IdUser" int   NOT NULL,
    CONSTRAINT "pk_Projects" PRIMARY KEY (
        "Id"
     )
);

CREATE TABLE "Tasks" (
    "Id"  SERIAL  NOT NULL,
    "Title" varchar(20)   NOT NULL,
    "Description" varchar(200)   NOT NULL,
    "DueDate" date   NOT NULL,
    "Status" int   NOT NULL,
    "IdProject" int   NOT NULL,
    CONSTRAINT "pk_Tasks" PRIMARY KEY (
        "Id"
     )
);

CREATE TABLE "Comments" (
    "Id"  SERIAL  NOT NULL,
    "IdTask" int   NOT NULL,
    "Text" varchar(250)   NOT NULL,
    CONSTRAINT "pk_Comments" PRIMARY KEY (
        "Id"
     )
);

CREATE TABLE "Logs" (
    "Id"  SERIAL  NOT NULL,
    "Field" varchar(50)   NOT NULL,
    "OldValue" varchar(250)   NOT NULL,
    "NewValue" varchar(250)   NOT NULL,
    "IdTask" int   NOT NULL,
    "IdUser" int   NOT NULL,
    CONSTRAINT "pk_Logs" PRIMARY KEY (
        "Id"
     )
);

ALTER TABLE "Projects" ADD CONSTRAINT "fk_Projects_IdUser" FOREIGN KEY("IdUser")
REFERENCES "Users" ("Id");

ALTER TABLE "Tasks" ADD CONSTRAINT "fk_Tasks_IdProject" FOREIGN KEY("IdProject")
REFERENCES "Projects" ("Id");

ALTER TABLE "Comments" ADD CONSTRAINT "fk_Comments_IdTask" FOREIGN KEY("IdTask")
REFERENCES "Tasks" ("Id");

ALTER TABLE "Logs" ADD CONSTRAINT "fk_Logs_IdTask" FOREIGN KEY("IdTask")
REFERENCES "Tasks" ("Id");

ALTER TABLE "Logs" ADD CONSTRAINT "fk_Logs_IdUser" FOREIGN KEY("IdUser")
REFERENCES "Users" ("Id");

