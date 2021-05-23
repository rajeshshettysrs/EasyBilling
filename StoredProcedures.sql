---------------------Getting user details--------------------
CREATE PROCEDURE USP_GetUsers
AS
BEGIN
	SELECT * FROM tbl_users
END

---------------------Inserting and updating-------------------
CREATE PROCEDURE USP_InsertUsersDetails
(
	@id int,
	@first_name varchar(50),
	@last_name varchar(50),
	@email varchar(150),
	@username varchar(50),
	@password varchar(50),
	@contact varchar(50),
	@address varchar(250),
	@gender varchar(10),
	@user_type varchar(50),
	@added_date datetime,
	@added_by int
)
AS
BEGIN
	DECLARE @COUNT AS Int;
	SET @COUNT = (SELECT COUNT(*) from tbl_users WHERE id=@id);
	IF(@COUNT > 0)
		BEGIN
			UPDATE tbl_users SET first_name=@first_name,last_name=@last_name,email=@email,username=@username,password=@password,contact=@contact,address=@address,gender=@gender,user_type=@user_type,added_date=@added_date,added_by=@added_by WHERE id=@id;
		END
	ELSE
		BEGIN
			INSERT INTO tbl_users(first_name,last_name,email,username,password,contact,address,gender,user_type,added_date,added_by) VALUES(@first_name,@last_name,@email,@username,@password,@contact,@address,@gender,@user_type,@added_date,@added_by);
		END
END

-----------------Deleting users----------------

CREATE PROCEDURE USP_DeleteUsers
(
	@id int
)
AS
BEGIN
	DELETE FROM tbl_users WHERE id=@id;
END

----------------Get Max User Id---------------------

CREATE PROCEDURE USP_GetUsersMaxId
AS
BEGIN
	SELECT ISNULL(MAX(id),0) AS MAXID FROM tbl_users
END

EXEC USP_GetUsersMaxId

------------Search users based on keyword-------------

CREATE PROCEDURE USP_SearchUsers
(
	@keyword varchar(100)
)
AS
BEGIN
	SELECT * FROM tbl_users WHERE CAST(id as varchar) LIKE '%' + ISNULL(@keyword,0) + '%' OR first_name LIKE '%'+ @keyword +'%' OR last_name LIKE '%'+ @keyword +'%' OR username LIKE '%'+ @keyword +'%' OR contact LIKE '%'+ @keyword +'%';
END

EXEC USP_SearchUsers '1'

------------------------------------------------------
