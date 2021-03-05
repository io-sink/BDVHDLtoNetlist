library IEEE;
use IEEE.std_logic_1164.all; 

entity 7411ic is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of 7411ic is "74xx";
	attribute component_name of 7411ic is "74HC11";
	attribute footprint_name of 7411ic is "Package_DIP:DIP-14_W7.62mm_Socket_LongPads";

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
	1C : in std_logic;
	attribute pin_assign of 1C is 13;
	1Y : out std_logic;
	attribute pin_assign of 1Y is 12;

	2A : in std_logic;
	attribute pin_assign of 2A is 3;
	2B : in std_logic;
	attribute pin_assign of 2B is 4;
	2C : in std_logic;
	attribute pin_assign of 2C is 5;
	2Y : out std_logic;
	attribute pin_assign of 2Y is 6;
	
	3A : in std_logic;
	attribute pin_assign of 3A is 9;
	3B : in std_logic;
	attribute pin_assign of 3B is 10;
	3C : in std_logic;
	attribute pin_assign of 3C is 11;
	3Y : out std_logic;
	attribute pin_assign of 3Y is 8
	
	);
	end 7411ic;

architecture logic of 7411ic is 
begin 

	1Y <= 1A and 1B and 1C;
	2Y <= 2A and 2B and 2C;
	3Y <= 3A and 3B and 3C;

end logic;