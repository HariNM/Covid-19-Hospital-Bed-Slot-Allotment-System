-- MySQL Script generated by MySQL Workbench
-- Mon Oct 23 02:42:52 2023
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`Hospitals`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Hospitals` (
  `HospitalId` INT NOT NULL,
  `HospitalName` VARCHAR(45) NULL,
  `Address` VARCHAR(255) NULL,
  `ContactNumber` VARCHAR(45) NULL,
  `NumberOfBeds` INT NULL,
  PRIMARY KEY (`HospitalId`),
  UNIQUE INDEX `HospitalId_UNIQUE` (`HospitalId` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`HospitalUsers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`HospitalUsers` (
  `UserId` INT NULL,
  `HospitalId` INT NULL,
  `HospitalUsersId` INT NOT NULL,
  INDEX `HospitalId_idx` (`HospitalId` ASC) VISIBLE,
  PRIMARY KEY (`HospitalUsersId`),
  UNIQUE INDEX `HospitalUsersId_UNIQUE` (`HospitalUsersId` ASC) VISIBLE,
  CONSTRAINT `HospitalId`
    FOREIGN KEY (`HospitalId`)
    REFERENCES `mydb`.`Hospitals` (`HospitalId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Users` (
  `UserId` INT NOT NULL,
  `Username` VARCHAR(45) NULL,
  `Password` VARCHAR(45) NULL,
  `HospitalUsersId` INT NULL,
  PRIMARY KEY (`UserId`),
  UNIQUE INDEX `UserId_UNIQUE` (`UserId` ASC) VISIBLE,
  INDEX `HospitalUsersId_idx` (`HospitalUsersId` ASC) VISIBLE,
  CONSTRAINT `HospitalUsersId`
    FOREIGN KEY (`HospitalUsersId`)
    REFERENCES `mydb`.`HospitalUsers` (`HospitalUsersId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
MAX_ROWS = 50
ROW_FORMAT = DYNAMIC;


-- -----------------------------------------------------
-- Table `mydb`.`Patients`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Patients` (
  `PatientId` INT NOT NULL,
  `Name` VARCHAR(45) NULL,
  `DateOfBirth` DATE NULL,
  `Gender` ENUM('Male', 'Female', 'Others') NULL,
  `BloodGroup` ENUM('A+', 'A-', 'B+', 'B-', 'O+', 'O-', 'AB+', 'AB-') NULL,
  `SeverityOfIllness` ENUM('Mild', 'Moderate', 'Severe') NULL,
  `UserId` INT NOT NULL,
  PRIMARY KEY (`PatientId`, `UserId`),
  UNIQUE INDEX `PatientId_UNIQUE` (`PatientId` ASC) VISIBLE,
  INDEX `fk_Patients_Users1_idx` (`UserId` ASC) VISIBLE,
  CONSTRAINT `UserId`
    FOREIGN KEY (`UserId`)
    REFERENCES `mydb`.`Users` (`UserId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Rooms`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Rooms` (
  `HospitalId` INT NULL,
  `RoomNumber` INT NOT NULL,
  `Capacity` INT NULL,
  PRIMARY KEY (`RoomNumber`),
  UNIQUE INDEX `RoomNumber_UNIQUE` (`RoomNumber` ASC) VISIBLE,
  INDEX `HospitalId_idx` (`HospitalId` ASC) VISIBLE,
  CONSTRAINT `HospitalId`
    FOREIGN KEY (`HospitalId`)
    REFERENCES `mydb`.`Hospitals` (`HospitalId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Beds`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Beds` (
  `BedId` INT NOT NULL,
  `Type` ENUM('General', 'ICU', 'Ventilator') NULL,
  `RoomNumber` INT NULL,
  PRIMARY KEY (`BedId`),
  UNIQUE INDEX `BedId_UNIQUE` (`BedId` ASC) VISIBLE,
  INDEX `RoomNumber_idx` (`RoomNumber` ASC) VISIBLE,
  CONSTRAINT `RoomNumber`
    FOREIGN KEY (`RoomNumber`)
    REFERENCES `mydb`.`Rooms` (`RoomNumber`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`BedAvailability`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`BedAvailability` (
  `BedAvailabilityId` INT NOT NULL,
  `BedId` INT NULL,
  `Availability` ENUM('Available', 'Occupied') NULL,
  PRIMARY KEY (`BedAvailabilityId`),
  UNIQUE INDEX `BedAvailabilityId_UNIQUE` (`BedAvailabilityId` ASC) VISIBLE,
  INDEX `BedId_idx` (`BedId` ASC) VISIBLE,
  CONSTRAINT `BedId`
    FOREIGN KEY (`BedId`)
    REFERENCES `mydb`.`Beds` (`BedId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Admissions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Admissions` (
  `AdmissionsId` INT NOT NULL,
  `PatientId` INT NULL,
  `AdmissionDate` DATE NULL,
  `DischargeDate` DATE NULL,
  PRIMARY KEY (`AdmissionsId`),
  UNIQUE INDEX `AvailabilityId_UNIQUE` (`AdmissionsId` ASC) VISIBLE,
  INDEX `PatientId_idx` (`PatientId` ASC) VISIBLE,
  CONSTRAINT `PatientId`
    FOREIGN KEY (`PatientId`)
    REFERENCES `mydb`.`Patients` (`PatientId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`SystemLogs`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`SystemLogs` (
  `LogId` INT NOT NULL,
  `UserId` INT NULL,
  `Action` VARCHAR(45) NULL,
  `Timestamp` DATETIME NULL,
  PRIMARY KEY (`LogId`),
  UNIQUE INDEX `LogId_UNIQUE` (`LogId` ASC) VISIBLE,
  INDEX `UserId_idx` (`UserId` ASC) VISIBLE,
  CONSTRAINT `UserId`
    FOREIGN KEY (`UserId`)
    REFERENCES `mydb`.`Users` (`UserId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Receptionist`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Receptionist` (
  `ReceptionistId` INT NOT NULL,
  `ReceptionistName` VARCHAR(45) NULL,
  `UserId` INT NULL,
  PRIMARY KEY (`ReceptionistId`),
  UNIQUE INDEX `ReceptionistId_UNIQUE` (`ReceptionistId` ASC) VISIBLE,
  INDEX `UserId_idx` (`UserId` ASC) VISIBLE,
  CONSTRAINT `UserId`
    FOREIGN KEY (`UserId`)
    REFERENCES `mydb`.`Users` (`UserId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
