CREATE LOGIN [Johny] WITH PASSWORD = 'password';
USE [JetStreamServiceRequest];
CREATE USER [Johny] FOR LOGIN [Johny];
        GRANT SELECT, INSERT, UPDATE, DELETE TO [Johny];