library IEEE;
use IEEE.std_logic_1164.all; 

entity ic7486 is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of ic7486 is "74xx";
	attribute component_name of ic7486 is "74HC86";
	attribute footprint_name of ic7486 is "Package_DIP:DIP-14_W7.62mm_Socket_LongPads";

	GND : in std_logic;
	attribute const_assign of GND is "GND";
	attribute pin_assign of GND is 7;
	attribute pin_type of GND is "power_in";
	VCC : in std_logic;
	attribute const_assign of VCC is "VCC";
	attribute pin_assign of VCC is 14;
	attribute pin_type of VCC is "power_in";

	A1 : in std_logic;
	attribute pin_assign of A1 is 1;
	attribute pin_type of A1 is "input";
	B1 : in std_logic;
	attribute pin_assign of B1 is 2;
	attribute pin_type of B1 is "input";
	Y1 : out std_logic;
	attribute pin_assign of Y1 is 3;
	attribute pin_type of Y1 is "output";

	A2 : in std_logic;
	attribute pin_assign of A2 is 4;
	attribute pin_type of A2 is "input";
	B2 : in std_logic;
	attribute pin_assign of B2 is 5;
	attribute pin_type of B2 is "input";
	Y2 : out std_logic;
	attribute pin_assign of Y2 is 6;
	attribute pin_type of Y2 is "output";
	
	A3 : in std_logic;
	attribute pin_assign of A3 is 9;
	attribute pin_type of A3 is "input";
	B3 : in std_logic;
	attribute pin_assign of B3 is 10;
	attribute pin_type of B3 is "input";
	Y3 : out std_logic;
	attribute pin_assign of Y3 is 8;
	attribute pin_type of Y3 is "output";
	
	A4 : in std_logic;
	attribute pin_assign of A4 is 12;
	attribute pin_type of A4 is "input";
	B4 : in std_logic;
	attribute pin_assign of B4 is 13;
	attribute pin_type of B4 is "input";
	Y4 : out std_logic;
	attribute pin_assign of Y4 is 11;
	attribute pin_type of Y4 is "output"
	);
	end ic7486;

architecture logic of ic7486 is 
begin 

	Y1 <= A1 xor B1;
	Y2 <= A2 xor B2;
	Y3 <= A3 xor B3;
	Y4 <= A4 xor B4;

end logic;