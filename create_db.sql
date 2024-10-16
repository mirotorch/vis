CREATE TABLE user (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    username TEXT NOT NULL UNIQUE,
    password TEXT NOT NULL,
    email TEXT NOT NULL UNIQUE,
    first_name TEXT,
    last_name TEXT,
    date_joined DATETIME DEFAULT CURRENT_TIMESTAMP,
    last_login DATETIME,
    is_active BOOLEAN DEFAULT 1
); 

CREATE TABLE clinic (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    address TEXT NOT NULL
);

CREATE TABLE doctor (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    user_id INTEGER,
    field TEXT NOT NULL,
    contact_number TEXT NOT NULL,
    clinic_id INTEGER,
    FOREIGN KEY (user_id) REFERENCES user(id) ON DELETE CASCADE,
    FOREIGN KEY (clinic_id) REFERENCES clinic(id) ON DELETE CASCADE
);


CREATE TABLE doctor_schedule (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    doctor_id INTEGER,
    date DATE NOT NULL,
    start_time TIME NOT NULL,
    end_time TIME NOT NULL,
    FOREIGN KEY (doctor_id) REFERENCES doctor(id) ON DELETE CASCADE
);


CREATE TABLE patient (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    user_id INTEGER,
    contact_number TEXT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES user(id) ON DELETE CASCADE
);

CREATE TABLE consultation (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    beginning DATETIME NOT NULL,
    end DATETIME,
    state TEXT NOT NULL,
    location_id INTEGER,
    doctor_id INTEGER,
    patient_id INTEGER,
    mark TEXT,
    FOREIGN KEY (location_id) REFERENCES clinic(id) ON DELETE CASCADE,
    FOREIGN KEY (doctor_id) REFERENCES doctor(id) ON DELETE CASCADE,
    FOREIGN KEY (patient_id) REFERENCES patient(id) ON DELETE CASCADE
);

CREATE TABLE medical_record (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    patient_id INTEGER,
    doctor_id INTEGER,
    consultation_id INTEGER,
    diagnosis TEXT,
    prescription TEXT,
    date DATE NOT NULL,
    FOREIGN KEY (patient_id) REFERENCES patient(id) ON DELETE CASCADE,
    FOREIGN KEY (doctor_id) REFERENCES doctor(id) ON DELETE CASCADE,
    FOREIGN KEY (consultation_id) REFERENCES consultation(id) ON DELETE CASCADE
);

CREATE TABLE review (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    patient_id INTEGER,
    doctor_id INTEGER,
    rating INTEGER CHECK(rating >= 1 AND rating <= 5),
    comment TEXT,   
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (patient_id) REFERENCES patient(id) ON DELETE CASCADE,
    FOREIGN KEY (doctor_id) REFERENCES doctor(id) ON DELETE CASCADE
);

CREATE TABLE laboratory (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    working_hours TEXT NOT NULL,
    daily_quota INTEGER NOT NULL DEFAULT 0
);

CREATE TABLE laboratory_request (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    laboratory_id INTEGER,
    sent DATETIME DEFAULT CURRENT_TIMESTAMP,
    processed DATETIME,
    result TEXT,
    consultation_id INTEGER,
    FOREIGN KEY (laboratory_id) REFERENCES laboratory(id) ON DELETE CASCADE,
    FOREIGN KEY (consultation_id) REFERENCES consultation(id) ON DELETE CASCADE
);

