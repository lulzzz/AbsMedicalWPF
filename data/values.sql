﻿INSERT INTO `rfid`.`country` (`Id`, `Name`) VALUES ('1', 'France'), ('2', 'Belgique');

INSERT INTO `rfid`.`school` (`Guid`, `Name`, `Address`, `PostalCode`, `City`, `Email`, `Phone`, `CountryId`) VALUES ('149e8107-16bf-4771-95d3-b48933a9ede2', 'SophiaTech', '350 route des Colles', '06220', 'Vallauris', 'contact@unice.fr', '0655884477', '1');

INSERT INTO `rfid`.`doctor` (`Guid`, `Lastname`, `Firstname`, `Address`, `PostalCode`, `City`, `Email`, `Password`, `Phone`, `CountryId`, `MailConfigurationGuid`) VALUES ('5bd4b179-ae28-473d-af41-877b8b3fc3ac
', 'Stefano', 'Martines', 'Avenue Leon Montier', '06590', 'Theoule', 'stefano.martines@hotmail.com', '9e5267ca171a20b9a28d63ff7237f2b8', '0622114455', '1', NULL);

INSERT INTO `rfid`.`student` (`Guid`, `Lastname`, `Firstname`, `Email`, `Phone`, `Birthdate`, `Birthplace`, `StudentId`, `SocialSecurityNumber`, `Address`, `PostalCode`, `City`, `CountryId`, `SchoolGuid`) VALUES ('ab839316', 'White', 'Card', 'white.card@gmail.com', '0611223344', '2017-03-01', 'Nice', 'ab839316', 'ab839316ab839316', '16 avenue de Nice', '06000', 'Nice', '1', '149e8107-16bf-4771-95d3-b48933a9ede2');
INSERT INTO `rfid`.`student` (`Guid`, `Lastname`, `Firstname`, `Email`, `Phone`, `Birthdate`, `Birthplace`, `StudentId`, `SocialSecurityNumber`, `Address`, `PostalCode`, `City`, `CountryId`, `SchoolGuid`) VALUES ('04617c4a', 'Stefano', 'Martines', 'stefano.martines@hotmail.com', '0699835052', '1995-06-10', 'Tourcoing', '04617c4a', '04617c4a04617c4a', '16 avenue Léon Montier', '06590', 'Theoule sur Mer', '1', '149e8107-16bf-4771-95d3-b48933a9ede2');