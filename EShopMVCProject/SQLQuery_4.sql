INSERT INTO CategoryVariation (CategoryId, Variationname) VALUES
(2, 'Color'),
( 2, 'Storage Capacity'),
( 3, 'Color'),
( 3, 'Storage Capacity');


INSERT INTO ProductCategories (Name, ParentCategoryId) VALUES
('Electronics', NULL),
('Smartphones', 1),
('Laptops', 1),
('Tablets', 1),
('Cameras', 1),
('Audio', 1),
('Accessories', 1),
('Networking', 1),
('Gaming', 1),
('Smart Home', 1),
('Lighting', 1),
('Chargers', 1),
('Peripherals', 1),
('Storage', 1),
('Monitors', 1),
('Printers', 1),
('Virtual Reality', 1),
('Microphones', 1),
('Drones', 1),
('Projectors', 1);

-- Add more variations as needed