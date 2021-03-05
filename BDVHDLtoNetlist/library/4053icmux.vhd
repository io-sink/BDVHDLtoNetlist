LIBRARY ieee;
USE ieee.std_logic_1164.all; 

ENTITY 4053icmux IS 
PORT
	(
		ATTRIBUTE library_name : string;
		ATTRIBUTE component_name : string;
		ATTRIBUTE footprint_name : string;
		ATTRIBUTE const_assign : string;
		ATTRIBUTE pin_assign : integer;

		ATTRIBUTE library_name OF 4053icmux IS "4xxx";
		ATTRIBUTE component_name OF 4053icmux IS "4053";
		ATTRIBUTE footprint_name OF 4053icmux IS "Package_DIP:DIP-16_W7.62mm_Socket_LongPads";

		VSS : IN STD_LOGIC;
		ATTRIBUTE const_assign OF VSS IS "GND";
		ATTRIBUTE pin_assign OF VSS IS 8;
		VEE : IN STD_LOGIC;
		ATTRIBUTE const_assign OF VEE IS "GND";
		ATTRIBUTE pin_assign OF VEE IS 7;
		VDD : IN STD_LOGIC;
		ATTRIBUTE const_assign OF VDD IS "VCC";
		ATTRIBUTE pin_assign OF VDD IS 16;
		INH : IN STD_LOGIC;
		ATTRIBUTE const_assign OF INH IS "GND";
		ATTRIBUTE pin_assign OF INH IS 6;

		0X : IN STD_LOGIC;
		ATTRIBUTE pin_assign OF 0X IS 12;
		1X : IN STD_LOGIC;
		ATTRIBUTE pin_assign OF 1X IS 13;
		A : IN STD_LOGIC;
		ATTRIBUTE pin_assign OF A IS 11;
		X_COM : OUT STD_LOGIC;
		ATTRIBUTE pin_assign OF X_COM IS 14;

		0Y : IN STD_LOGIC;
		ATTRIBUTE pin_assign OF 0Y IS 2;
		1Y : IN STD_LOGIC;
		ATTRIBUTE pin_assign OF 1Y IS 1;
		B : IN STD_LOGIC;
		ATTRIBUTE pin_assign OF B IS 10;
		Y_COM : OUT STD_LOGIC;
		ATTRIBUTE pin_assign OF Y_COM IS 15;

		0Z : IN STD_LOGIC;
		ATTRIBUTE pin_assign OF 0Z IS 5;
		1Z : IN STD_LOGIC;
		ATTRIBUTE pin_assign OF 1Z IS 3;
		C : IN STD_LOGIC;
		ATTRIBUTE pin_assign OF C IS 9;
		Z_COM : OUT STD_LOGIC;
		ATTRIBUTE pin_assign OF Z_COM IS 4
	);
END 4053icmux;

ARCHITECTURE logic OF 4053icmux IS 

	COMPONENT 21mux
		PORT(S : IN STD_LOGIC;
			B : IN STD_LOGIC;
			A : IN STD_LOGIC;
			Y : OUT STD_LOGIC);
	END COMPONENT;

BEGIN 

	mux0 : 21mux
	PORT MAP(
			S => A,
			A => 0X,
			B => 1X,
			Y => X_COM);

	mux1 : 21mux
	PORT MAP(
			S => B,
			A => 0Y,
			B => 1Y,
			Y => Y_COM);
			
	mux2 : 21mux
	PORT MAP(
			S => C,
			A => 0Z,
			B => 1Z,
			Y => Z_COM);

END logic;