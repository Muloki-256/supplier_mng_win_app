-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 04, 2026 at 03:53 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `supplier_management_system`
--

-- --------------------------------------------------------

--
-- Table structure for table `deliveries`
--

CREATE TABLE `deliveries` (
  `delivery_id` int(11) NOT NULL,
  `po_id` int(11) NOT NULL,
  `delivery_date` date NOT NULL,
  `status` varchar(20) NOT NULL DEFAULT 'COMPLETE',
  `remarks` varchar(255) DEFAULT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `deliveries`
--

INSERT INTO `deliveries` (`delivery_id`, `po_id`, `delivery_date`, `status`, `remarks`, `created_at`) VALUES
(1, 1, '2026-05-02', 'COMPLETE', 'Delivered in full', '2026-05-04 12:21:42'),
(2, 2, '2026-05-04', 'PARTIAL', 'Awaiting balance stock', '2026-05-04 12:21:42'),
(3, 3, '2026-05-06', 'COMPLETE', 'All items delivered', '2026-05-04 12:21:42'),
(4, 4, '2026-05-08', 'PENDING', 'Awaiting delivery', '2026-05-04 12:21:42'),
(5, 5, '2026-05-12', 'COMPLETE', 'Delivered on time', '2026-05-04 12:21:42');

-- --------------------------------------------------------

--
-- Table structure for table `payments`
--

CREATE TABLE `payments` (
  `payment_id` int(11) NOT NULL,
  `invoice_id` int(11) NOT NULL,
  `payment_date` date NOT NULL,
  `amount_paid` decimal(14,2) NOT NULL,
  `payment_method` varchar(30) NOT NULL,
  `reference_no` varchar(60) DEFAULT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `payments`
--

INSERT INTO `payments` (`payment_id`, `invoice_id`, `payment_date`, `amount_paid`, `payment_method`, `reference_no`, `created_at`) VALUES
(1, 1, '2026-05-03', 1000000.00, 'MOBILE_MONEY', 'MM-AGRI-1001', '2026-05-04 12:21:42'),
(2, 1, '2026-05-10', 1450000.00, 'BANK_TRANSFER', 'BT-AGRI-2001', '2026-05-04 12:21:42'),
(3, 3, '2026-05-07', 1550000.00, 'CASH', 'CASH-001', '2026-05-04 12:21:42'),
(4, 5, '2026-05-13', 1600000.00, 'MOBILE_MONEY', 'MM-AGRI-1002', '2026-05-04 12:21:42');

-- --------------------------------------------------------

--
-- Table structure for table `po_items`
--

CREATE TABLE `po_items` (
  `item_id` int(11) NOT NULL,
  `po_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `unit_price` decimal(14,2) NOT NULL,
  `total_price` decimal(14,2) GENERATED ALWAYS AS (`quantity` * `unit_price`) STORED,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `po_items`
--

INSERT INTO `po_items` (`item_id`, `po_id`, `product_id`, `quantity`, `unit_price`, `created_at`) VALUES
(1, 1, 1, 100, 12000.00, '2026-05-04 12:21:42'),
(2, 1, 2, 50, 25000.00, '2026-05-04 12:21:42'),
(3, 2, 2, 30, 28000.00, '2026-05-04 12:21:42'),
(4, 3, 3, 10, 85000.00, '2026-05-04 12:21:42'),
(5, 3, 4, 20, 35000.00, '2026-05-04 12:21:42'),
(6, 4, 1, 80, 11500.00, '2026-05-04 12:21:42'),
(7, 4, 5, 60, 8000.00, '2026-05-04 12:21:42'),
(8, 5, 6, 200, 5000.00, '2026-05-04 12:21:42'),
(9, 5, 7, 50, 12000.00, '2026-05-04 12:21:42');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `product_id` int(11) NOT NULL,
  `product_name` varchar(120) NOT NULL,
  `unit` varchar(20) NOT NULL,
  `reorder_level` int(11) NOT NULL DEFAULT 10,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`product_id`, `product_name`, `unit`, `reorder_level`, `created_at`) VALUES
(1, 'Maize Seeds (10kg)', 'bag', 30, '2026-05-04 12:21:42'),
(2, 'NPK Fertilizer 50kg', 'bag', 40, '2026-05-04 12:21:42'),
(3, 'Knapsack Sprayer', 'piece', 15, '2026-05-04 12:21:42'),
(4, 'Pesticide 1L', 'bottle', 25, '2026-05-04 12:21:42'),
(5, 'Bean Seeds (5kg)', 'bag', 20, '2026-05-04 12:21:42'),
(6, 'Hoe', 'piece', 50, '2026-05-04 12:21:42'),
(7, 'Watering Can', 'piece', 30, '2026-05-04 12:21:42'),
(8, 'Maize Seeds (10kg)', 'bag', 30, '2026-05-04 13:13:40'),
(9, 'NPK Fertilizer 50kg', 'bag', 40, '2026-05-04 13:13:40'),
(10, 'Knapsack Sprayer', 'piece', 15, '2026-05-04 13:13:40'),
(11, 'Pesticide 1L', 'bottle', 25, '2026-05-04 13:13:40'),
(12, 'Bean Seeds (5kg)', 'bag', 20, '2026-05-04 13:13:40'),
(13, 'Hoe', 'piece', 50, '2026-05-04 13:13:40'),
(14, 'Watering Can', 'piece', 30, '2026-05-04 13:13:40'),
(15, 'Maize Seeds (10kg)', 'bag', 30, '2026-05-04 13:15:09'),
(16, 'NPK Fertilizer 50kg', 'bag', 40, '2026-05-04 13:15:09'),
(17, 'Knapsack Sprayer', 'piece', 15, '2026-05-04 13:15:09'),
(18, 'Pesticide 1L', 'bottle', 25, '2026-05-04 13:15:09'),
(19, 'Bean Seeds (5kg)', 'bag', 20, '2026-05-04 13:15:09'),
(20, 'Hoe', 'piece', 50, '2026-05-04 13:15:09'),
(21, 'Watering Can', 'piece', 30, '2026-05-04 13:15:09'),
(22, 'Maize Seeds (10kg)', 'bag', 30, '2026-05-04 13:15:44'),
(23, 'NPK Fertilizer 50kg', 'bag', 40, '2026-05-04 13:15:44'),
(24, 'Knapsack Sprayer', 'piece', 15, '2026-05-04 13:15:44'),
(25, 'Pesticide 1L', 'bottle', 25, '2026-05-04 13:15:44'),
(26, 'Bean Seeds (5kg)', 'bag', 20, '2026-05-04 13:15:44'),
(27, 'Hoe', 'piece', 50, '2026-05-04 13:15:44'),
(28, 'Watering Can', 'piece', 30, '2026-05-04 13:15:44');

-- --------------------------------------------------------

--
-- Table structure for table `purchase_orders`
--

CREATE TABLE `purchase_orders` (
  `po_id` int(11) NOT NULL,
  `po_number` varchar(30) NOT NULL,
  `supplier_id` int(11) NOT NULL,
  `order_date` date NOT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `purchase_orders`
--

INSERT INTO `purchase_orders` (`po_id`, `po_number`, `supplier_id`, `order_date`, `created_at`) VALUES
(1, 'PO-2026-001', 1, '2026-05-01', '2026-05-04 12:21:42'),
(2, 'PO-2026-002', 2, '2026-05-02', '2026-05-04 12:21:42'),
(3, 'PO-2026-003', 3, '2026-05-03', '2026-05-04 12:21:42'),
(4, 'PO-2026-004', 4, '2026-05-05', '2026-05-04 12:21:42'),
(5, 'PO-2026-005', 5, '2026-05-10', '2026-05-04 12:21:42');

-- --------------------------------------------------------

--
-- Table structure for table `suppliers`
--

CREATE TABLE `suppliers` (
  `supplier_id` int(11) NOT NULL,
  `supplier_name` varchar(120) NOT NULL,
  `contact_person` varchar(100) DEFAULT NULL,
  `phone` varchar(20) NOT NULL,
  `location_area` varchar(100) DEFAULT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `suppliers`
--

INSERT INTO `suppliers` (`supplier_id`, `supplier_name`, `contact_person`, `phone`, `location_area`, `created_at`) VALUES
(1, 'Masaka Seed Traders', 'Nabwire Sarah', '+256772100210', 'Masaka Town', '2026-05-04 12:21:42'),
(2, 'Bukakata Agro Inputs', 'Ssenfuma Denis', '+256703440122', 'Bukakata', '2026-05-04 12:21:42'),
(3, 'Nyendo Farm Supplies', 'Kato Brian', '+256751334455', 'Nyendo', '2026-05-04 12:21:42'),
(4, 'Kalungu Fertilizers Ltd', 'Mukasa John', '+256782345678', 'Kalungu', '2026-05-04 12:21:42'),
(5, 'Masaka Hardware Supplies', 'Kyeyune Peter', '+256701234567', 'Masaka Industrial Area', '2026-05-04 12:21:42'),
(6, 'Masaka Seed Traders', 'Nabwire Sarah', '+256772100210', 'Masaka Town', '2026-05-04 13:13:40'),
(7, 'Bukakata Agro Inputs', 'Ssenfuma Denis', '+256703440122', 'Bukakata', '2026-05-04 13:13:40'),
(8, 'Nyendo Farm Supplies', 'Kato Brian', '+256751334455', 'Nyendo', '2026-05-04 13:13:40'),
(9, 'Kalungu Fertilizers Ltd', 'Mukasa John', '+256782345678', 'Kalungu', '2026-05-04 13:13:40'),
(10, 'Masaka Hardware Supplies', 'Kyeyune Peter', '+256701234567', 'Masaka Industrial Area', '2026-05-04 13:13:40'),
(11, 'Masaka Seed Traders', 'Nabwire Sarah', '+256772100210', 'Masaka Town', '2026-05-04 13:15:09'),
(12, 'Bukakata Agro Inputs', 'Ssenfuma Denis', '+256703440122', 'Bukakata', '2026-05-04 13:15:09'),
(13, 'Nyendo Farm Supplies', 'Kato Brian', '+256751334455', 'Nyendo', '2026-05-04 13:15:09'),
(14, 'Kalungu Fertilizers Ltd', 'Mukasa John', '+256782345678', 'Kalungu', '2026-05-04 13:15:09'),
(15, 'Masaka Hardware Supplies', 'Kyeyune Peter', '+256701234567', 'Masaka Industrial Area', '2026-05-04 13:15:09'),
(16, 'Masaka Seed Traders', 'Nabwire Sarah', '+256772100210', 'Masaka Town', '2026-05-04 13:15:44'),
(17, 'Bukakata Agro Inputs', 'Ssenfuma Denis', '+256703440122', 'Bukakata', '2026-05-04 13:15:44'),
(18, 'Nyendo Farm Supplies', 'Kato Brian', '+256751334455', 'Nyendo', '2026-05-04 13:15:44'),
(19, 'Kalungu Fertilizers Ltd', 'Mukasa John', '+256782345678', 'Kalungu', '2026-05-04 13:15:44'),
(20, 'Masaka Hardware Supplies', 'Kyeyune Peter', '+256701234567', 'Masaka Industrial Area', '2026-05-04 13:15:44'),
(22, 'Masaka Seed Traders', 'Nabwire Sarah', '+256772100210', 'Masaka Town', '2026-05-04 16:15:36');

-- --------------------------------------------------------

--
-- Table structure for table `supplier_invoices`
--

CREATE TABLE `supplier_invoices` (
  `invoice_id` int(11) NOT NULL,
  `supplier_id` int(11) NOT NULL,
  `invoice_number` varchar(50) NOT NULL,
  `invoice_date` date NOT NULL,
  `invoice_amount` decimal(14,2) NOT NULL,
  `status` varchar(20) NOT NULL DEFAULT 'UNPAID',
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `supplier_invoices`
--

INSERT INTO `supplier_invoices` (`invoice_id`, `supplier_id`, `invoice_number`, `invoice_date`, `invoice_amount`, `status`, `created_at`) VALUES
(1, 1, 'INV-MAS-001', '2026-05-02', 2450000.00, 'PARTIAL', '2026-05-04 12:21:42'),
(2, 2, 'INV-BUK-001', '2026-05-04', 840000.00, 'UNPAID', '2026-05-04 12:21:42'),
(3, 3, 'INV-NYE-001', '2026-05-06', 1550000.00, 'PAID', '2026-05-04 12:21:42'),
(4, 4, 'INV-KAL-001', '2026-05-08', 1400000.00, 'UNPAID', '2026-05-04 12:21:42'),
(5, 5, 'INV-MHH-001', '2026-05-12', 1600000.00, 'PAID', '2026-05-04 12:21:42');

-- --------------------------------------------------------

--
-- Table structure for table `supplier_products`
--

CREATE TABLE `supplier_products` (
  `supplier_product_id` int(11) NOT NULL,
  `supplier_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `supplier_products`
--

INSERT INTO `supplier_products` (`supplier_product_id`, `supplier_id`, `product_id`, `created_at`) VALUES
(1, 1, 1, '2026-05-04 12:21:42'),
(2, 1, 2, '2026-05-04 12:21:42'),
(3, 2, 2, '2026-05-04 12:21:42'),
(4, 3, 3, '2026-05-04 12:21:42'),
(5, 3, 4, '2026-05-04 12:21:42'),
(6, 4, 1, '2026-05-04 12:21:42'),
(7, 4, 5, '2026-05-04 12:21:42'),
(8, 5, 6, '2026-05-04 12:21:42'),
(9, 5, 7, '2026-05-04 12:21:42');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `full_name` varchar(100) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `role` enum('ADMIN','MANAGER','CLERK') NOT NULL DEFAULT 'CLERK',
  `is_active` tinyint(1) NOT NULL DEFAULT 1,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `full_name`, `username`, `password_hash`, `role`, `is_active`, `created_at`) VALUES
(1, 'Kulaba Brendah', 'admin', 'admin123', 'ADMIN', 1, '2026-05-04 12:21:42'),
(2, 'Damalie Dorcas', 'damalie', 'damalie123', 'MANAGER', 1, '2026-05-04 12:21:42'),
(15, 'Angel Nakalema', 'angel', 'angel123', 'CLERK', 1, '2026-05-04 16:48:28');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `deliveries`
--
ALTER TABLE `deliveries`
  ADD PRIMARY KEY (`delivery_id`),
  ADD KEY `fk_delivery_po` (`po_id`);

--
-- Indexes for table `payments`
--
ALTER TABLE `payments`
  ADD PRIMARY KEY (`payment_id`),
  ADD KEY `fk_payment_invoice` (`invoice_id`);

--
-- Indexes for table `po_items`
--
ALTER TABLE `po_items`
  ADD PRIMARY KEY (`item_id`),
  ADD KEY `fk_pitem_po` (`po_id`),
  ADD KEY `fk_pitem_product` (`product_id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`product_id`);

--
-- Indexes for table `purchase_orders`
--
ALTER TABLE `purchase_orders`
  ADD PRIMARY KEY (`po_id`),
  ADD UNIQUE KEY `po_number` (`po_number`),
  ADD KEY `fk_po_supplier` (`supplier_id`);

--
-- Indexes for table `suppliers`
--
ALTER TABLE `suppliers`
  ADD PRIMARY KEY (`supplier_id`);

--
-- Indexes for table `supplier_invoices`
--
ALTER TABLE `supplier_invoices`
  ADD PRIMARY KEY (`invoice_id`),
  ADD UNIQUE KEY `uq_supplier_invoice` (`supplier_id`,`invoice_number`);

--
-- Indexes for table `supplier_products`
--
ALTER TABLE `supplier_products`
  ADD PRIMARY KEY (`supplier_product_id`),
  ADD UNIQUE KEY `uk_supplier_product` (`supplier_id`,`product_id`),
  ADD KEY `fk_sp_product` (`product_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `deliveries`
--
ALTER TABLE `deliveries`
  MODIFY `delivery_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `payments`
--
ALTER TABLE `payments`
  MODIFY `payment_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `po_items`
--
ALTER TABLE `po_items`
  MODIFY `item_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT for table `purchase_orders`
--
ALTER TABLE `purchase_orders`
  MODIFY `po_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `suppliers`
--
ALTER TABLE `suppliers`
  MODIFY `supplier_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `supplier_invoices`
--
ALTER TABLE `supplier_invoices`
  MODIFY `invoice_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `supplier_products`
--
ALTER TABLE `supplier_products`
  MODIFY `supplier_product_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `deliveries`
--
ALTER TABLE `deliveries`
  ADD CONSTRAINT `fk_delivery_po` FOREIGN KEY (`po_id`) REFERENCES `purchase_orders` (`po_id`) ON DELETE CASCADE;

--
-- Constraints for table `payments`
--
ALTER TABLE `payments`
  ADD CONSTRAINT `fk_payment_invoice` FOREIGN KEY (`invoice_id`) REFERENCES `supplier_invoices` (`invoice_id`) ON DELETE CASCADE;

--
-- Constraints for table `po_items`
--
ALTER TABLE `po_items`
  ADD CONSTRAINT `fk_pitem_po` FOREIGN KEY (`po_id`) REFERENCES `purchase_orders` (`po_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_pitem_product` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`);

--
-- Constraints for table `purchase_orders`
--
ALTER TABLE `purchase_orders`
  ADD CONSTRAINT `fk_po_supplier` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`) ON DELETE CASCADE;

--
-- Constraints for table `supplier_invoices`
--
ALTER TABLE `supplier_invoices`
  ADD CONSTRAINT `fk_invoice_supplier` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`) ON DELETE CASCADE;

--
-- Constraints for table `supplier_products`
--
ALTER TABLE `supplier_products`
  ADD CONSTRAINT `fk_sp_product` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_sp_supplier` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
