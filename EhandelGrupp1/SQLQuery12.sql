SELECT * FROM dbo.Product


INSERT INTO dbo.Product
        ( name ,
          description ,
          price ,
          stock ,
          date ,
          isHidden
        )
VALUES  ( 'Blyertspenna Office HB gul' , -- name - varchar(50)
          'Blyertspenna lackad i gul färg. Hårdhet: HB. 12fp' , -- description - varchar(max)
          27 , -- price - money
          534 , -- stock - int
          GETDATE() , -- date - datetime
          0  -- isHidden - tinyint
        )