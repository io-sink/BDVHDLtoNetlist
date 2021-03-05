library IEEE;
use IEEE.std_logic_1164.all; 

entity 7400ic is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of 7400ic is "74xx";
	attribute component_name of 7400ic is "74HC00";
	attribute footprint_name of 7400ic is "Package_DIP:DIP-14_W7.62mm_Socket_LongPads";

	GND : in std_logic;
	attribute const_assign of GND is "GND";
	attribute pin_assign of GND is 7;
	VCC : in std_logic;
	attribute const_assign of VCC is "VCC";
	attribute pin_assign of VCC is 14;

	1A : in std_logic;
	attribute pin_assign of 1A is 1;
	1B : in std_logic;
	attribute pin_assign of 1B is 2;
	1Y : out std_logic;
	attribute pin_assign of 1Y is 3;

	2A : in std_logic;
	attribute pin_assign of 2A is 4;
	2B : in std_logic;
	attribute pin_assign of 2B is 5;
	2Y : out std_logic;
	attribute pin_assign of 2Y is 6;
	
	3A : in std_logic;
	attribute pin_assign of 3A is 9;
	3B : in std_logic;
	attribute pin_assign of 3B is 10;
	3Y : out std_logic;
	attribute pin_assign of 3Y is 8;
	
	4A : in std_logic;
	attribute pin_assign of 4A is 12;
	4B : in std_logic;
	attribute pin_assign of 4B is 13;
	4Y : out std_logic;
	attribute pin_assign of 4Y is 11
	);
	end 7400ic;

architecture logic of 7400ic is 
begin 

	1Y <= 1A nand 1B;
	2Y <= 2A nand 2B;
	3Y <= 3A nand 3B;
	4Y <= 4A nand 4B;

end logic;