library IEEE;
use IEEE.std_logic_1164.all; 

entity ic7404 is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of ic7404 is "74xx";
	attribute component_name of ic7404 is "74HC04";
	attribute footprint_name of ic7404 is "Package_DIP:DIP-14_W7.62mm_Socket_LongPads";

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
	Y1 : out std_logic;
	attribute pin_assign of Y1 is 2;
	attribute pin_type of Y1 is "output";

	A2 : in std_logic;
	attribute pin_assign of A2 is 3;
	attribute pin_type of A2 is "input";
	Y2 : out std_logic;
	attribute pin_assign of Y2 is 4;
	attribute pin_type of Y2 is "output";

	A3 : in std_logic;
	attribute pin_assign of A3 is 5;
	attribute pin_type of A3 is "input";
	Y3 : out std_logic;
	attribute pin_assign of Y3 is 6;
	attribute pin_type of Y3 is "output";

	A4 : in std_logic;
	attribute pin_assign of A4 is 9;
	attribute pin_type of A4 is "input";
	Y4 : out std_logic;
	attribute pin_assign of Y4 is 8;
	attribute pin_type of Y4 is "output";

	A5 : in std_logic;
	attribute pin_assign of A5 is 11;
	attribute pin_type of A5 is "input";
	Y5 : out std_logic;
	attribute pin_assign of Y5 is 10;
	attribute pin_type of Y5 is "output";

	A6 : in std_logic;
	attribute pin_assign of A6 is 13;
	attribute pin_type of A6 is "input";
	Y6 : out std_logic;
	attribute pin_assign of Y6 is 12;
	attribute pin_type of Y6 is "output"
	);
	end ic7404;

architecture logic of ic7404 is 
begin 

	Y1 <= not A1;
	Y2 <= not A2;
	Y3 <= not A3;
	Y4 <= not A4;
	Y5 <= not A5;
	Y6 <= not A6;

end logic;