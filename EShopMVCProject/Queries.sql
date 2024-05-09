USE ECommerceDB

select * from Products;
select *  from ProductCategories;


-- Insert dummy data for Customer table
INSERT INTO Customers (FirstName, LastName, Gender, Phone, ProfilePic, UserId)
VALUES
    ('John', 'Doe', 'Male', '1234567890', 'profile1.jpg', 101),
    ('Jane', 'Doe', 'Female', '0987654321', 'profile2.jpg', 102),
    ('Alice', 'Smith', 'Female', '9876543210', 'profile3.jpg', 103),
    ('Bob', 'Johnson', 'Male', '4567890123', 'profile4.jpg', 104);

-- Insert dummy data for Address table
INSERT INTO Addresses (Street1, City, Zipcode, State, Country)
VALUES
    ('123 Main St', 'New York', '10001', 'NY', 'USA'),
    ('456 Elm St', 'Los Angeles', '90001', 'CA', 'USA'),
    ('789 Oak St', 'Chicago', '60601', 'IL', 'USA'),
    ('101 Pine St', 'Houston', '77001', 'TX', 'USA');

-- Insert dummy data for UserAddress table
INSERT INTO UserAddresses (CustomerId, AddressId, IsDefaultAddress)
VALUES
    (1, 1, 1), -- John Doe's default address
    (1, 2, 0), -- John Doe's additional address
    (2, 3, 1), -- Jane Doe's default address
    (3, 4, 1), -- Alice Smith's default address
    (4, 1, 1); -- Bob Johnson's default address


UPDATE Products
SET 
    Name = 'Updated Product Name',
    Description = 'Updated Product Description',
    CategoryId = 17, -- Updated CategoryId
    Price = 99.99, -- Updated Price
    Qty = 20, -- Updated Quantity
    Product_image = 'updated_image_url.jpg',
    SKU = '12345678' -- Updated SKU
WHERE 
    ID = 10; -- Specify the ID of the product you want to update


Delete CategoryVariation;

-- Reset identity seed for the CategoryVariation table
DBCC CHECKIDENT ('CategoryVariation', RESEED, 0);


INSERT INTO CategoryVariation (Category_Id, Variation_Name)
VALUES 
    (1, 'Color'),       -- Electronics
    (1, 'Size'),        -- Electronics
    (2, 'Gender'),      -- Clothing
    (2, 'Style'),       -- Clothing
    (3, 'Genre'),       -- Books
    (3, 'Author'),      -- Books
    (4, 'Material'),    -- Home & Kitchen
    (4, 'Type'),        -- Home & Kitchen
    (5, 'Age Group'),   -- Toys & Games
    (5, 'Theme');  

-- Insert dummy data into ProductCategory table
INSERT INTO ProductCategories (Name, Parent_category_Id)
VALUES 
    ('Electronics', 4), -- Top-level category
    ('Mobile Phones', 1),  -- Child category of Electronics
    ('Laptops', 1),        -- Child category of Electronics
    ('Clothing', 4),    -- Top-level category
    ('Men''s Clothing', 4), -- Child category of Clothing
    ('Women''s Clothing', 4), -- Child category of Clothing
    ('Books', 3),       -- Top-level category
    ('Fiction', 7),        -- Child category of Books
    ('Non-Fiction', 7),    -- Child category of Books
    ('Home & Kitchen', 4), -- Top-level category
    ('Kitchen Appliances', 10), -- Child category of Home & Kitchen
    ('Home Decor', 10);    -- Child category of Home & Kitchen
/*
-- Insert data into ProductCategories table
INSERT INTO ProductCategories (Name, Parent_category_Id)
VALUES 
    ('Electronics', 1), -- Color
    ('Clothing', 2),     -- Size
    ('Books', 3),        -- Gender
    ('Home & Kitchen', 4),  -- Style
    ('Toys & Games', 5),    -- Genre
    ('Sports & Outdoors', 6),  -- Author
    ('Beauty & Personal Care', 7),  -- Material
    ('Automotive', 8),     -- Type
    ('Health & Household', 9),   -- Age Group
    ('Tools & Home Improvement', 10);  -- Theme
    
*/

select ID,Name,[Description],CategoryId,Price,Qty,Product_image,SKU from Products;

-- Inserting dummy values into the Products table
INSERT INTO Products (Name, [Description], CategoryId, Price, Qty, Product_image, SKU)
VALUES 
    ('iPhone 12', 'The iPhone 12 is a powerful smartphone with a sleek design and advanced features.', 15, 999.99, 100, 'https://example.com/iphone12.jpg', 'SKU123'),
    ('Samsung Galaxy S21', 'The Samsung Galaxy S21 is a premium Android smartphone with a stunning display and impressive camera.', 16, 899.99, 120, 'https://example.com/samsung_s21.jpg', 'SKU456'),
    ('HP Pavilion x360', 'The HP Pavilion x360 is a versatile 2-in-1 laptop with a touchscreen display and long battery life.', 16, 799.99, 80, 'https://example.com/hp_pavilion_x360.jpg', 'SKU789'),
    ('Dell Inspiron', 'The Dell Inspiron is a reliable laptop with powerful performance and a comfortable keyboard.', 16, 699.99, 90, 'https://example.com/dell_inspiron.jpg', 'SKU321'),
    ('Nike T-Shirt', 'The Nike T-Shirt is made from soft, breathable fabric and features the iconic Nike logo.', 18, 29.99, 200, 'https://example.com/nike_tshirt.jpg', 'SKU654'),
    ('Adidas Hoodie', 'The Adidas Hoodie is a comfortable and stylish sweatshirt perfect for everyday wear.', 18, 49.99, 150, 'https://example.com/adidas_hoodie.jpg', 'SKU987'),
    ('Harry Potter and the Sorcerer''s Stone', 'Harry Potter and the Sorcerer''s Stone is the first book in the Harry Potter series by J.K. Rowling.', 22, 14.99, 300, 'https://example.com/harry_potter_book.jpg', 'SKU654'),
    ('Sapiens: A Brief History of Humankind', 'Sapiens: A Brief History of Humankind is a thought-provoking exploration of human history by Yuval Noah Harari.', 23, 19.99, 250, 'https://example.com/sapiens_book.jpg', 'SKU987'),
    ('KitchenAid Stand Mixer', 'The KitchenAid Stand Mixer is a versatile kitchen appliance perfect for baking and cooking.', 25, 299.99, 50, 'https://example.com/kitchenaid_mixer.jpg', 'SKU321'),
    ('Decorative Throw Pillow', 'The Decorative Throw Pillow adds a pop of color and style to any living space.', 26, 39.99, 100, 'https://example.com/throw_pillow.jpg', 'SKU654');
 
select * from ProductCategories;