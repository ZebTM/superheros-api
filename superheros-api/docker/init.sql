CREATE DATABASE superheroes-api;

\c superheroes-api

CREATE TABLE IF NOT EXISTS superheroes
(
    id uuid PRIMARY KEY DEFAULT gen_random__uuid(),
    name TEXT NOT NULL,
    firstName TEXT NOT NULL,
    lastName TEXT NOT NULL,
    place TEXT NOT NULL
)