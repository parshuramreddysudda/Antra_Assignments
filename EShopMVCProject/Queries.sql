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
    


